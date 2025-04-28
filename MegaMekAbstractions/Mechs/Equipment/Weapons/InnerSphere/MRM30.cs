namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MRM 30 weapon.
/// </summary>
public sealed class MRM30 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MRM30"/> class.
    /// </summary>
    public MRM30() : base("MRM 30", 915, 48.0m, 0, 1, 530, 0, 3, 10, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 10;
    }
}
