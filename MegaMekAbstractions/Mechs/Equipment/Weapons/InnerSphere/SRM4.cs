namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the SRM 4 weapon.
/// </summary>
public sealed class SRM4 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SRM4"/> class.
    /// </summary>
    public SRM4() : base("SRM 4", 46, 13.0m, 0, 3, 2, 24, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 79;
    }
}
