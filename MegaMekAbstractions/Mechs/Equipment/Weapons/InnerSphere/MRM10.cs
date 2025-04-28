namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MRM 10 weapon.
/// </summary>
public sealed class MRM10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MRM10"/> class.
    /// </summary>
    public MRM10() : base("MRM 10", 915, 48.0m, 0, 1, 510, 0, 3, 4, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 3;
    }
}
