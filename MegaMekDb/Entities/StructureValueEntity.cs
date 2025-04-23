using MegaMekAbstractions.Mechs;

namespace MegaMekDb.Entities;

/// <summary>
/// Database entity representing a Mech's structure value at a specific location
/// </summary>
public class StructureValueEntity
{
    public int Id { get; set; }
    public int MechEntityId { get; set; }
    public Location Location { get; set; }
    public int Value { get; set; }
    
    // Navigation property
    public MechEntity? Mech { get; set; }
}
