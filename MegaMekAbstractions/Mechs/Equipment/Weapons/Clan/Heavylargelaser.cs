namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Heavy Large Laser weapon.
/// </summary>
public sealed class Heavylargelaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heavylargelaser"/> class.
    /// </summary>
    public Heavylargelaser() : base("Heavy Large Laser", 3, 4.0m, 18, 0, 5, 10, 15, 16, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
