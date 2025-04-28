namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Small Laser weapon.
/// </summary>
public sealed class Ersmalllaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ersmalllaser"/> class.
    /// </summary>
    public Ersmalllaser() : base("ER Small Laser", 1, 0.5.0m, 2, 0, 2, 4, 6, 5, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
