namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Improved Heavy Small Laser weapon.
/// </summary>
public sealed class ImprovedHeavySmallLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImprovedHeavySmallLaser"/> class.
    /// </summary>
    public ImprovedHeavySmallLaser() : base("Improved Heavy Small Laser", 05, 3.0m, 0, 6, 0, 1, 2, 3, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 1;
    }
}
