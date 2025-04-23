using MegaMekAbstractions.Common;

namespace MegaMekDb.Entities;

/// <summary>
/// Database entity representing a Quirk for a BattleMech
/// </summary>
public class QuirkEntity
{
    public int Id { get; set; }
    public int MechEntityId { get; set; }
    public Quirk Quirk { get; set; }
    
    // Navigation property
    public MechEntity? Mech { get; set; }
}
