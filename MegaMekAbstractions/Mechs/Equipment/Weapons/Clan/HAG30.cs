namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the HAG 30 weapon.
/// </summary>
public sealed class HAG30 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HAG30"/> class.
    /// </summary>
    public HAG30() : base("HAG 30", 916, 18.0m, 0, 0, 6, 530, 2, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1724;
    }
}
