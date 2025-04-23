using System.Security.Cryptography;
using System.Text;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Mechs.Equipment;
using MegaMekAbstractions.Parsers.Interfaces;
using MegaMekDb.Data;
using MegaMekDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MegaMekDb.Services;

/// <summary>
/// Service for importing and updating MTF files in the database
/// </summary>
public class MtfImportService
{
    private readonly MechDbContext _dbContext;
    private readonly IMtfParser _mtfParser;
    private readonly ILogger<MtfImportService> _logger;

    public MtfImportService(
        MechDbContext dbContext,
        IMtfParser mtfParser,
        ILogger<MtfImportService> logger)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mtfParser = mtfParser ?? throw new ArgumentNullException(nameof(mtfParser));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Imports an MTF file into the database
    /// </summary>
    /// <param name="filePath">Path to the MTF file</param>
    /// <param name="fileContent">The content of the MTF file</param>
    /// <returns>The ID of the imported or updated Mech</returns>
    public async Task<int> ImportMtfFileAsync(string filePath, string fileContent)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path cannot be empty", nameof(filePath));
        
        if (string.IsNullOrWhiteSpace(fileContent))
            throw new ArgumentException("File content cannot be empty", nameof(fileContent));

        // Calculate file hash
        string fileHash = CalculateHash(fileContent);
        
        // Check if this exact file content already exists in the database
        var existingMech = await _dbContext.Mechs.FirstOrDefaultAsync(m => m.FileHash == fileHash);
        if (existingMech != null)
        {
            _logger.LogInformation("MTF file with hash {Hash} already exists in the database with ID {Id}", fileHash, existingMech.Id);
            return existingMech.Id; // File already exists unchanged
        }

        // Parse the MTF content
        var mech = await _mtfParser.ParseMechDataAsync(fileContent);
        
        // Check if a mech with the same chassis and model exists
        existingMech = await _dbContext.Mechs
            .Include(m => m.Quirks)
            .Include(m => m.ArmorValues)
            .Include(m => m.StructureValues)
            .Include(m => m.Equipment)
            .FirstOrDefaultAsync(m => m.Chassis == mech.Chassis && m.Model == mech.Model);

        if (existingMech != null)
        {
            // Update the existing mech
            _logger.LogInformation("Updating existing mech {Chassis} {Model} (ID: {Id})", 
                mech.Chassis, mech.Model, existingMech.Id);
                
            await UpdateExistingMechAsync(existingMech, mech, filePath, fileHash);
            return existingMech.Id;
        }
        else
        {
            // Create a new mech
            _logger.LogInformation("Creating new mech {Chassis} {Model}", mech.Chassis, mech.Model);
            return await CreateNewMechAsync(mech, filePath, fileHash);
        }
    }

    /// <summary>
    /// Creates a new mech in the database
    /// </summary>
    private async Task<int> CreateNewMechAsync(Mech mech, string filePath, string fileHash)
    {
        var mechEntity = ConvertToMechEntity(mech, filePath, fileHash);
        
        _dbContext.Mechs.Add(mechEntity);
        await _dbContext.SaveChangesAsync();
        
        return mechEntity.Id;
    }

    /// <summary>
    /// Updates an existing mech in the database
    /// </summary>
    private async Task UpdateExistingMechAsync(MechEntity existingMech, Mech updatedMech, string filePath, string fileHash)
    {
        // Update basic information
        UpdateMechEntityFromMech(existingMech, updatedMech);
        
        // Update file information
        existingMech.FileName = Path.GetFileName(filePath);
        existingMech.FileHash = fileHash;
        existingMech.UpdatedAt = DateTime.UtcNow;
        
        // Clear existing child entities
        _dbContext.Quirks.RemoveRange(existingMech.Quirks);
        _dbContext.ArmorValues.RemoveRange(existingMech.ArmorValues);
        _dbContext.StructureValues.RemoveRange(existingMech.StructureValues);
        _dbContext.Equipment.RemoveRange(existingMech.Equipment);
        
        // Add new child entities
        AddChildEntities(existingMech, updatedMech);
        
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Converts a Mech object to a MechEntity
    /// </summary>
    private MechEntity ConvertToMechEntity(Mech mech, string filePath, string fileHash)
    {
        var mechEntity = new MechEntity
        {
            FileName = Path.GetFileName(filePath),
            FileHash = fileHash,
            ImportedAt = DateTime.UtcNow
        };
        
        UpdateMechEntityFromMech(mechEntity, mech);
        AddChildEntities(mechEntity, mech);
        
        return mechEntity;
    }
    
    /// <summary>
    /// Updates the basic properties of a MechEntity from a Mech
    /// </summary>
    private void UpdateMechEntityFromMech(MechEntity mechEntity, Mech mech)
    {
        mechEntity.Chassis = mech.Chassis;
        mechEntity.Model = mech.Model;
        mechEntity.MulId = mech.MulId;
        mechEntity.Configuration = mech.Configuration;
        mechEntity.TechBase = mech.TechBase;
        mechEntity.Era = mech.Era;
        mechEntity.Source = mech.Source;
        mechEntity.RulesLevel = mech.RulesLevel;
        mechEntity.GroundRole = mech.GroundRole;
        mechEntity.Mass = mech.Mass;
        
        // Core systems
        mechEntity.EngineRating = mech.Engine.Rating;
        mechEntity.EngineType = mech.Engine.Type;
        mechEntity.Gyro = mech.Gyro;
        mechEntity.Cockpit = mech.Cockpit;
        mechEntity.HeatSinkType = mech.HeatSinks.Type;
        mechEntity.HeatSinkCount = mech.HeatSinks.Count;
        
        // Structure and armor
        mechEntity.StructureType = mech.Structure.Type;
        mechEntity.ArmorType = mech.Armor.Type;
    }
    
    /// <summary>
    /// Adds child entities to a MechEntity from a Mech
    /// </summary>
    private void AddChildEntities(MechEntity mechEntity, Mech mech)
    {
        // Add quirks
        foreach (var quirk in mech.Quirks)
        {
            mechEntity.Quirks.Add(new QuirkEntity 
            { 
                Quirk = quirk 
            });
        }
        
        // Add armor values
        foreach (var loc in Enum.GetValues<Location>())
        {
            int value = mech.Armor.GetArmorValue(loc);
            if (value > 0)
            {
                mechEntity.ArmorValues.Add(new ArmorValueEntity 
                { 
                    Location = loc,
                    Value = value
                });
            }
        }
        
        // Add structure values
        foreach (var loc in Enum.GetValues<Location>())
        {
            int value = mech.Structure.GetStructureValue(loc);
            if (value > 0)
            {
                mechEntity.StructureValues.Add(new StructureValueEntity 
                { 
                    Location = loc,
                    Value = value
                });
            }
        }
        
        // Add equipment
        foreach (var location in mech.Criticals)
        {
            foreach (var equipment in location.Value.GetEquipment())
            {
                var equipmentEntity = new EquipmentEntity
                {
                    Location = location.Key,
                    Name = equipment.Name,
                    Quantity = 1,  // Default is 1, can be more for ammo
                    IsWeapon = equipment is Weapon,
                    CriticalSlots = equipment.CriticalSlots
                };
                
                if (equipment is Weapon weapon)
                {
                    equipmentEntity.Heat = weapon.Heat;
                    equipmentEntity.Damage = weapon.Damage.ToString();
                    equipmentEntity.MinimumRange = 0;  // Default if not specified
                    equipmentEntity.ShortRange = weapon.ShortRange;
                    equipmentEntity.MediumRange = weapon.MediumRange;
                    equipmentEntity.LongRange = weapon.LongRange;
                }
                else if (equipment is Ammunition ammo)
                {
                    equipmentEntity.AmmoType = ammo.AmmoType;
                }
                
                mechEntity.Equipment.Add(equipmentEntity);
            }
        }
    }
    
    /// <summary>
    /// Calculates a hash of the file content
    /// </summary>
    private string CalculateHash(string content)
    {
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(content));
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}
