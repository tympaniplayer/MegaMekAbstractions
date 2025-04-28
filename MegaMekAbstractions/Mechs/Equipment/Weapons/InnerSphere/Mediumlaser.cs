namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Medium Laser weapon.
/// </summary>
public sealed class Mediumlaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mediumlaser"/> class.
    /// </summary>
    public Mediumlaser() : base("Medium Laser", 1, 1.0m, 3, 0, 3, 6, 9, 5, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
