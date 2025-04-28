namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Enhanced LRM 10 weapon.
/// </summary>
public sealed class Enhancedlrm10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Enhancedlrm10"/> class.
    /// </summary>
    public Enhancedlrm10() : base("Enhanced LRM 10", 4, 6.0m, 4, 3, 7, 14, 21, 10, DamageTypeFlags.Cluster | DamageTypeFlags.Missile | DamageTypeFlags.SwitchableAmmo)
    {
        ShotsPerTon = 12;
    }
}
