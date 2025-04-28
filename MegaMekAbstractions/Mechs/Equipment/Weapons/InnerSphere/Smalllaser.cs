namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Small Laser weapon.
/// </summary>
public sealed class Smalllaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Smalllaser"/> class.
    /// </summary>
    public Smalllaser() : base("Small Laser", 1, 0.5.0m, 1, 0, 1, 2, 3, 3, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
