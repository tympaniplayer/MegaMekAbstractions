namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the SRM 2 weapon.
/// </summary>
public sealed class SRM2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SRM2"/> class.
    /// </summary>
    public SRM2() : base("SRM 2", 46, 13.0m, 0, 2, 2, 22, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 79;
    }
}
