namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ATM HE Ammo weapon.
/// </summary>
public sealed class ATMHEAmmo : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ATMHEAmmo"/> class.
    /// </summary>
    public ATMHEAmmo() : base("ATM HE Ammo", 1, 79.0m, 0, 5, 0, 3, 6, 3, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 0;
    }
}
