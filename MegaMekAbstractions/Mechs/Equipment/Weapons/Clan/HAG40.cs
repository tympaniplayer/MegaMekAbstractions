namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the HAG 40 weapon.
/// </summary>
public sealed class HAG40 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HAG40"/> class.
    /// </summary>
    public HAG40() : base("HAG 40", 916, 18.0m, 0, 0, 8, 540, 2, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1724;
    }
}
