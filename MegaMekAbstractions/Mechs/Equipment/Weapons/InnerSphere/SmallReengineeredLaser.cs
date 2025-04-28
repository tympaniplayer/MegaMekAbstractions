namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Small Re-engineered Laser weapon.
/// </summary>
public sealed class SmallReengineeredLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SmallReengineeredLaser"/> class.
    /// </summary>
    public SmallReengineeredLaser() : base("Small Re-engineered Laser", 1, 1.5.0m, 4, 0, 1, 2, 3, 4, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
