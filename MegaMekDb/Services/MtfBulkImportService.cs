using System.Security.Cryptography;
using System.Text;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Mechs.Equipment;
using MegaMekAbstractions.Parsers.Constants;
using MegaMekAbstractions.Parsers.Interfaces;
using MegaMekDb.Data;
using MegaMekDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MegaMekDb.Services;

/// <summary>
/// Service for bulk importing MTF files from directories
/// </summary>
public class MtfBulkImportService
{
    private readonly MechDbContext _dbContext;
    private readonly MtfImportService _importService;
    private readonly IMechFileReader _fileReader;
    private readonly IMtfParser _mtfParser;
    private readonly ILogger<MtfBulkImportService> _logger;

    public MtfBulkImportService(
        MechDbContext dbContext,
        MtfImportService importService,
        IMechFileReader fileReader,
        IMtfParser mtfParser,
        ILogger<MtfBulkImportService> logger)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _importService = importService ?? throw new ArgumentNullException(nameof(importService));
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        _mtfParser = mtfParser ?? throw new ArgumentNullException(nameof(mtfParser));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Import all MTF files from a directory and its subdirectories
    /// </summary>
    /// <param name="directoryPath">Path to the directory containing MTF files</param>
    /// <param name="recursiveSearch">Whether to search subdirectories recursively</param>
    /// <returns>A tuple containing counts of (Total, Added, Updated, Skipped) files</returns>
    public async Task<(int Total, int Added, int Updated, int Skipped)> ImportMtfFilesFromDirectoryAsync(
        string directoryPath, bool recursiveSearch = true)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentException("Directory path cannot be empty", nameof(directoryPath));

        if (!Directory.Exists(directoryPath))
            throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");

        // Look for all MTF files in the directory
        var searchOption = recursiveSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        var mtfFiles = Directory.GetFiles(directoryPath, $"*{MtfConstants.Extensions.Mtf}", searchOption);

        _logger.LogInformation("Found {Count} MTF files in {Directory}", mtfFiles.Length, directoryPath);

        int added = 0;
        int updated = 0;
        int skipped = 0;
        Dictionary<string, HashSet<string>> existingMechs = new();

        // Process each file
        foreach (var filePath in mtfFiles)
        {
            try
            {
                string fileContent = await _fileReader.ReadFileContentAsync(filePath);

                var fileName = Path.GetFileName(filePath);
                
                // Check if file already exists in the database by exact content hash
                var fileHash = CalculateHash(fileContent);
                var existingMech = await _dbContext.Mechs.FirstOrDefaultAsync(m => m.FileHash == fileHash);
                
                if (existingMech != null)
                {
                    skipped++;
                    _logger.LogInformation("Skipped MTF file (already exists): {FilePath}", filePath);
                    continue;
                }
                
                // Check if a mech with the same chassis and model exists
                var content = await _mtfParser.ParseMechDataAsync(fileContent);
                existingMech = await _dbContext.Mechs.FirstOrDefaultAsync(m => 
                    m.Chassis == content.Chassis && m.Model == content.Model);
                
                var result = await _importService.ImportMtfFileAsync(filePath, fileContent);
                
                if (existingMech != null)
                {
                    updated++;
                    _logger.LogInformation("Updated MTF file: {FilePath}", filePath);
                }
                else
                {
                    added++;
                    _logger.LogInformation("Added new MTF file: {FilePath}", filePath);
                }
            }
            catch (Exception ex)
            {
                skipped++;
                _logger.LogError(ex, "Failed to import MTF file: {FilePath}", filePath);
            }
        }

        return (mtfFiles.Length, added, updated, skipped);
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
