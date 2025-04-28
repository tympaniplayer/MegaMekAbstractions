namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LRM 20 weapon.
/// </summary>
public sealed class LRM20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LRM20"/> class.
    /// </summary>
    public LRM20() : base("LRM 20", 814, 17.0m, 0, 6, 1, 520, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1521;
    }
}
