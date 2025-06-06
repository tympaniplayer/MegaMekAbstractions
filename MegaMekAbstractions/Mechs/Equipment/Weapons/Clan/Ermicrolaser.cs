namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Micro Laser weapon.
/// </summary>
public sealed class Ermicrolaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ermicrolaser"/> class.
    /// </summary>
    public Ermicrolaser() : base("ER Micro Laser", 1, 0.25m, 1, 0, 1, 2, 4, 2, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
