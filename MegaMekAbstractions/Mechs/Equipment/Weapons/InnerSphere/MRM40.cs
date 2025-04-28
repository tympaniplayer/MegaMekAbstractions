namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MRM 40 weapon.
/// </summary>
public sealed class MRM40 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MRM40"/> class.
    /// </summary>
    public MRM40() : base("MRM 40", 915, 48.0m, 0, 1, 540, 0, 3, 12, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 12;
    }
}
