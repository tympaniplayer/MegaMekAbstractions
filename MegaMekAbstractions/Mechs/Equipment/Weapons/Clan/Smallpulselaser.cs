namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Small Pulse Laser weapon.
/// </summary>
public sealed class Smallpulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Smallpulselaser"/> class.
    /// </summary>
    public Smallpulselaser() : base("Small Pulse Laser", 1, 56.0m, 0, 3, 0, 2, 4, 2, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
