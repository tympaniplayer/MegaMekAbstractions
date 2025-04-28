namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the SRM 6 weapon.
/// </summary>
public sealed class SRM6 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SRM6"/> class.
    /// </summary>
    public SRM6() : base("SRM 6", 46, 13.0m, 0, 4, 2, 26, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 79;
    }
}
