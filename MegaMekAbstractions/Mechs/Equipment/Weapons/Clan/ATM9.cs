namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ATM 9 weapon.
/// </summary>
public sealed class ATM9 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ATM9"/> class.
    /// </summary>
    public ATM9() : base("ATM 9", 610, 15.0m, 0, 6, 2, 59, 4, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1115;
    }
}
