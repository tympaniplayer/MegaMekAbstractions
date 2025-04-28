namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Small Pulse Laser weapon.
/// </summary>
public sealed class Smallpulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Smallpulselaser"/> class.
    /// </summary>
    public Smallpulselaser() : base("Small Pulse Laser", 1, 3.0m, 0, 3, 0, 1, 2, 2, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
