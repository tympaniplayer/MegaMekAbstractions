namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the HAG 20 weapon.
/// </summary>
public sealed class HAG20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HAG20"/> class.
    /// </summary>
    public HAG20() : base("HAG 20", 916, 18.0m, 0, 0, 4, 520, 2, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1724;
    }
}
