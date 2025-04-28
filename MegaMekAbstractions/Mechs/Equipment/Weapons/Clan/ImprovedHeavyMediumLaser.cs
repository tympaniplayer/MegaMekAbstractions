namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Improved Heavy Medium Laser weapon.
/// </summary>
public sealed class ImprovedHeavyMediumLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImprovedHeavyMediumLaser"/> class.
    /// </summary>
    public ImprovedHeavyMediumLaser() : base("Improved Heavy Medium Laser", 1, 79.0m, 0, 10, 0, 3, 6, 7, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 2;
    }
}
