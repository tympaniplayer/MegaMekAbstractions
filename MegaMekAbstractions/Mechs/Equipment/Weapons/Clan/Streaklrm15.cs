namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Streak LRM 15 weapon.
/// </summary>
public sealed class Streaklrm15 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Streaklrm15"/> class.
    /// </summary>
    public Streaklrm15() : base("Streak LRM 15", 1521, 814.0m, 0, 1, 515, 0, 7, 5, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 7;
    }
}
