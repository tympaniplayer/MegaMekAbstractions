namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ATM 6 weapon.
/// </summary>
public sealed class ATM6 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ATM6"/> class.
    /// </summary>
    public ATM6() : base("ATM 6", 610, 15.0m, 0, 4, 2, 56, 4, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1115;
    }
}
