using MegaMekAbstractions.Common;
using MegaMekAbstractions.Mechs;

namespace MegaMekDb.Entities;

/// <summary>
/// Database entity representing a BattleMech
/// </summary>
public class MechEntity
{
    public int Id { get; set; }
    
    // File info
    public string FileName { get; set; } = string.Empty;
    public string FileHash { get; set; } = string.Empty;
    public DateTime ImportedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Basic Information
    public string Chassis { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int MulId { get; set; }
    public Configuration Configuration { get; set; }
    public TechBase TechBase { get; set; }
    public int Era { get; set; }
    public string Source { get; set; } = string.Empty;
    public RulesLevel RulesLevel { get; set; }
    public GroundRole GroundRole { get; set; }
    public int Mass { get; set; }

    // Core Systems
    public int EngineRating { get; set; }
    public EngineType EngineType { get; set; }
    public Gyro Gyro { get; set; }
    public Cockpit Cockpit { get; set; }
    public HeatSinkType HeatSinkType { get; set; }
    public int HeatSinkCount { get; set; }

    // Structure and Armor
    public StructureType StructureType { get; set; }
    public ArmorType ArmorType { get; set; }
    
    // Navigation properties
    public List<QuirkEntity> Quirks { get; set; } = new();
    public List<ArmorValueEntity> ArmorValues { get; set; } = new();
    public List<StructureValueEntity> StructureValues { get; set; } = new();
    public List<EquipmentEntity> Equipment { get; set; } = new();
}
