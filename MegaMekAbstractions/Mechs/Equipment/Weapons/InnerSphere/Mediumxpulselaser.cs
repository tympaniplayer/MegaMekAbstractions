namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Medium X-Pulse Laser weapon.
/// </summary>
public sealed class Mediumxpulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mediumxpulselaser"/> class.
    /// </summary>
    public Mediumxpulselaser() : base("Medium X-Pulse Laser", 1, 2.0m, 6, 0, 3, 6, 9, 6, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
