namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Pulse Small Laser weapon.
/// </summary>
public sealed class Erpulsesmalllaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Erpulsesmalllaser"/> class.
    /// </summary>
    public Erpulsesmalllaser() : base("ER Pulse Small Laser", 15, 56.0m, 0, 5, 0, 2, 4, 3, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
