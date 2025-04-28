namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LB 20-X AC weapon.
/// </summary>
public sealed class  : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref=""/> class.
    /// </summary>
    public () : base(
        name: "LB 20-X AC",
        criticalSlots: 9,
        tonnage: 12.0m,
        heat: 6,
        minimumRange: 0,
        shortRange: 4,
        mediumRange: 8,
        longRange: 12,
        damage: 20,
        damageTypeFlags: DamageTypeFlags.DirectFireBallistic SwitchableAmmo)
    {
        ShotsPerTon = 5;
    }
}
