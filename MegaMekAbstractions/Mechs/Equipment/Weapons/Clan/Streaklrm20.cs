namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Streak LRM 20 weapon.
/// </summary>
public sealed class Streaklrm20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Streaklrm20"/> class.
    /// </summary>
    public Streaklrm20() : base("Streak LRM 20", 1521, 814.0m, 0, 1, 520, 0, 7, 6, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 10;
    }
}
