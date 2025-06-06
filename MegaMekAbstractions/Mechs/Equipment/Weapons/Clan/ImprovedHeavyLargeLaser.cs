namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Improved Heavy Large Laser weapon.
/// </summary>
public sealed class ImprovedHeavyLargeLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImprovedHeavyLargeLaser"/> class.
    /// </summary>
    public ImprovedHeavyLargeLaser() : base("Improved Heavy Large Laser", 4, 1115.0m, 0, 16, 0, 5, 10, 18, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 3;
    }
}
