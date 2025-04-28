namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Small VSP Laser weapon.
/// </summary>
public sealed class SmallVSPLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SmallVSPLaser"/> class.
    /// </summary>
    public SmallVSPLaser() : base("Small VSP Laser", 56, 34.0m, 0, 3, 543, 0, 2, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 2;
    }
}
