namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ATM 12 weapon.
/// </summary>
public sealed class ATM12 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ATM12"/> class.
    /// </summary>
    public ATM12() : base("ATM 12", 610, 15.0m, 0, 8, 2, 512, 4, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1115;
    }
}
