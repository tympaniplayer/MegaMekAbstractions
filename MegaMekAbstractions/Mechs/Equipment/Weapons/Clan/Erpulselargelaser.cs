namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Pulse Large Laser weapon.
/// </summary>
public sealed class Erpulselargelaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Erpulselargelaser"/> class.
    /// </summary>
    public Erpulselargelaser() : base("ER Pulse Large Laser", 3, 6.0m, 13, 0, 7, 15, 23, 10, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
