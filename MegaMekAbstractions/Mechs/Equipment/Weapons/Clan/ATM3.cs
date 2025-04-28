namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ATM 3 weapon.
/// </summary>
public sealed class ATM3 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ATM3"/> class.
    /// </summary>
    public ATM3() : base("ATM 3", 610, 15.0m, 0, 2, 2, 53, 4, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1115;
    }
}
