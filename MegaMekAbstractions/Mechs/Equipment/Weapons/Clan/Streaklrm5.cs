namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Streak LRM 5 weapon.
/// </summary>
public sealed class Streaklrm5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Streaklrm5"/> class.
    /// </summary>
    public Streaklrm5() : base("Streak LRM 5", 1521, 814.0m, 0, 1, 55, 0, 7, 2, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 2;
    }
}
