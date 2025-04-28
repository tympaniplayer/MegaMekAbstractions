namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Pulse Medium Laser weapon.
/// </summary>
public sealed class Erpulsemediumlaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Erpulsemediumlaser"/> class.
    /// </summary>
    public Erpulsemediumlaser() : base("ER Pulse Medium Laser", 2, 2.0m, 6, 0, 5, 9, 14, 7, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
