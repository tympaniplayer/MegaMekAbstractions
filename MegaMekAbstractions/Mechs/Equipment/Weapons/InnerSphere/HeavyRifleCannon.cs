namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Heavy Rifle (Cannon) weapon.
/// </summary>
public sealed class HeavyRifleCannon : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeavyRifleCannon"/> class.
    /// </summary>
    public HeavyRifleCannon() : base("Heavy Rifle (Cannon)", 3, 8.0m, 4, 2, 6, 12, 18, 9, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 6;
    }
}
