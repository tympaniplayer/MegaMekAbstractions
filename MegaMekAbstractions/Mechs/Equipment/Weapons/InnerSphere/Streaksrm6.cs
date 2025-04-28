namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Streak SRM 6 weapon.
/// </summary>
public sealed class Streaksrm6 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Streaksrm6"/> class.
    /// </summary>
    public Streaksrm6() : base("Streak SRM 6", 79, 46.0m, 0, 2, 26, 0, 3, 4, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 45;
    }
}
