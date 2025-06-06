namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the ER Large Laser weapon.
/// </summary>
public sealed class Erlargelaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Erlargelaser"/> class.
    /// </summary>
    public Erlargelaser() : base("ER Large Laser", 2, 5.0m, 12, 0, 7, 14, 19, 8, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
