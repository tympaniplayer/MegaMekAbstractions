namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Medium Laser weapon.
/// </summary>
public sealed class Ermediumlaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ermediumlaser"/> class.
    /// </summary>
    public Ermediumlaser() : base("ER Medium Laser", 1, 1.0m, 5, 0, 5, 10, 15, 7, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
