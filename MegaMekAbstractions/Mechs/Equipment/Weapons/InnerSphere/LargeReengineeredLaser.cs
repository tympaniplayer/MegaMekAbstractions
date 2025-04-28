namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Large Re-engineered Laser weapon.
/// </summary>
public sealed class LargeReengineeredLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LargeReengineeredLaser"/> class.
    /// </summary>
    public LargeReengineeredLaser() : base("Large Re-engineered Laser", 5, 8.0m, 9, 0, 5, 10, 15, 9, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
