namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Micro Pulse Laser weapon.
/// </summary>
public sealed class Micropulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Micropulselaser"/> class.
    /// </summary>
    public Micropulselaser() : base("Micro Pulse Laser", 05, 3.0m, 0, 3, 0, 1, 2, 1, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
