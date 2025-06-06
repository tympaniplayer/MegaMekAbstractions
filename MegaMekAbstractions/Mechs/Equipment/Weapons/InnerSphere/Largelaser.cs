namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Large Laser weapon.
/// </summary>
public sealed class Largelaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Largelaser"/> class.
    /// </summary>
    public Largelaser() : base("Large Laser", 2, 5.0m, 8, 0, 5, 10, 15, 8, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
