namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

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
        criticalSlots:  14,
        tonnage: 912.0m,
        heat: 0,
        minimumRange: 20,
        shortRange: 0,
        mediumRange: 4,
        longRange: 8,
        damage: 6,
        damageTypeFlags: DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon =  11;
    }
}
