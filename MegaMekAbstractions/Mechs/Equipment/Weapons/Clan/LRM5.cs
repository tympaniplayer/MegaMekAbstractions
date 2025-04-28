namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LRM 5 weapon.
/// </summary>
public sealed class LRM5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LRM5"/> class.
    /// </summary>
    public LRM5() : base("LRM 5", 814, 17.0m, 0, 2, 1, 55, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1521;
    }
}
