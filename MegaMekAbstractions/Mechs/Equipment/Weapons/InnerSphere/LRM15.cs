namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the LRM 15 weapon.
/// </summary>
public sealed class LRM15 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LRM15"/> class.
    /// </summary>
    public LRM15() : base("LRM 15", 814, 17.0m, 0, 5, 1, 515, 6, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1521;
    }
}
