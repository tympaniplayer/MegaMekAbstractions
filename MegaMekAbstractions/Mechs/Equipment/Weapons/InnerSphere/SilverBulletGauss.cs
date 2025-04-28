namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Silver Bullet Gauss weapon.
/// </summary>
public sealed class SilverBulletGauss : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SilverBulletGauss"/> class.
    /// </summary>
    public SilverBulletGauss() : base("Silver Bullet Gauss", 815, 17.0m, 0, 0, 1, 115, 2, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1622;
    }
}
