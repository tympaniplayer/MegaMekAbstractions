namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Medium VSP Laser weapon.
/// </summary>
public sealed class MediumVSPLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediumVSPLaser"/> class.
    /// </summary>
    public MediumVSPLaser() : base("Medium VSP Laser", 69, 35.0m, 0, 7, 975, 0, 2, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 4;
    }
}
