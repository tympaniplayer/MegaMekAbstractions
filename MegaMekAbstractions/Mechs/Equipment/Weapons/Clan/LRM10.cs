namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LRM 10 weapon.
/// </summary>
public sealed class LRM10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LRM10"/> class.
    /// </summary>
    public LRM10() : base("LRM 10", 814, 17.0m, 0, 4, 1, 510, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1521;
    }
}
