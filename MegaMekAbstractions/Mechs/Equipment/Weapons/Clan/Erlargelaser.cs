namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Large Laser weapon.
/// </summary>
public sealed class Erlargelaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Erlargelaser"/> class.
    /// </summary>
    public Erlargelaser() : base("ER Large Laser", 1, 4.0m, 12, 0, 8, 15, 25, 10, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
