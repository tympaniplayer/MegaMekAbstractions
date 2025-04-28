namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Magshot Gauss Rifle weapon.
/// </summary>
public sealed class MagshotGauss : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MagshotGauss"/> class.
    /// </summary>
    public MagshotGauss() : base("Magshot Gauss Rifle", 05, 79.0m, 0, 2, 0, 3, 6, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 2;
    }
}
