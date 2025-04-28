namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Light Gauss Rifle weapon.
/// </summary>
public sealed class LightGauss : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LightGauss"/> class.
    /// </summary>
    public LightGauss() : base("Light Gauss Rifle", 12, 1825.0m, 0, 8, 3, 8, 17, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 5;
    }
}
