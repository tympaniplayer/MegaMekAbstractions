namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Streak LRM 10 weapon.
/// </summary>
public sealed class Streaklrm10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Streaklrm10"/> class.
    /// </summary>
    public Streaklrm10() : base("Streak LRM 10", 1521, 814.0m, 0, 1, 510, 0, 7, 4, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 5;
    }
}
