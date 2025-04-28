namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Streak SRM 4 weapon.
/// </summary>
public sealed class Streaksrm4 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Streaksrm4"/> class.
    /// </summary>
    public Streaksrm4() : base("Streak SRM 4", 79, 46.0m, 0, 2, 24, 0, 3, 3, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 3;
    }
}
