namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MRM 20 weapon.
/// </summary>
public sealed class MRM20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MRM20"/> class.
    /// </summary>
    public MRM20() : base("MRM 20", 915, 48.0m, 0, 1, 520, 0, 3, 6, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 7;
    }
}
