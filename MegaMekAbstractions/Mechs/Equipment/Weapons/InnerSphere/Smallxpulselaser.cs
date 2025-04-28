namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Small X-Pulse Laser weapon.
/// </summary>
public sealed class Smallxpulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Smallxpulselaser"/> class.
    /// </summary>
    public Smallxpulselaser() : base("Small X-Pulse Laser", 1, 5.0m, 0, 3, 0, 2, 4, 3, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
