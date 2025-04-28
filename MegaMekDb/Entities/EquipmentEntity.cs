using MegaMekAbstractions.Mechs;

namespace MegaMekDb.Entities;

/// <summary>
/// Database entity representing equipment installed on a Mech
/// </summary>
public class EquipmentEntity
{
    public int Id { get; set; }
    public int MechEntityId { get; set; }
    public Location Location { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public bool IsWeapon { get; set; }
    public int CriticalSlots { get; set; }
    
    // For weapons
    public int? Heat { get; set; }
    public int? Damage { get; set; }
    public int? MinimumRange { get; set; }
    public int? ShortRange { get; set; }
    public int? MediumRange { get; set; }
    public int? LongRange { get; set; }
    public string? AmmoType { get; set; }
    
    // Navigation property
    public MechEntity? Mech { get; set; }
}
