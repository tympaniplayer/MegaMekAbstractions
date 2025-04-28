namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Heavy Gauss Rifle weapon.
/// </summary>
public sealed class HeavyGauss : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeavyGauss"/> class.
    /// </summary>
    public HeavyGauss() : base("Heavy Gauss Rifle", 1420, 713.0m, 0, 2, 252010, 4, 6, 0, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 18;
    }
}
