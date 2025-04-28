namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Improved Heavy Gauss weapon.
/// </summary>
public sealed class ImprovedHeavyGauss : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImprovedHeavyGauss"/> class.
    /// </summary>
    public ImprovedHeavyGauss() : base("Improved Heavy Gauss", 11, 20.0m, 2, 3, 6, 12, 19, 22, DamageTypeFlags.DirectFireBallistic | DamageTypeFlags.Explosive)
    {
        ShotsPerTon = 4;
    }
}
