namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Medium Re-engineered Laser weapon.
/// </summary>
public sealed class MediumReengineeredLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediumReengineeredLaser"/> class.
    /// </summary>
    public MediumReengineeredLaser() : base("Medium Re-engineered Laser", 2, 2.5.0m, 6, 0, 3, 6, 9, 6, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
