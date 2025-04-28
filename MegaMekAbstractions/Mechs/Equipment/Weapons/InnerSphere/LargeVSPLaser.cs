namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Large VSP Laser weapon.
/// </summary>
public sealed class LargeVSPLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LargeVSPLaser"/> class.
    /// </summary>
    public LargeVSPLaser() : base("Large VSP Laser", 915, 58.0m, 0, 10, 1197, 0, 4, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 9;
    }
}
