namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ATM ER Ammo weapon.
/// </summary>
public sealed class ATMERAmmo : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ATMERAmmo"/> class.
    /// </summary>
    public ATMERAmmo() : base("ATM ER Ammo", 1, 1927.0m, 0, 5, 4, 9, 18, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 0;
    }
}
