namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Streak SRM 2 weapon.
/// </summary>
public sealed class Streaksrm2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Streaksrm2"/> class.
    /// </summary>
    public Streaksrm2() : base("Streak SRM 2", 912, 58.0m, 0, 2, 22, 0, 4, 2, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1;
    }
}
