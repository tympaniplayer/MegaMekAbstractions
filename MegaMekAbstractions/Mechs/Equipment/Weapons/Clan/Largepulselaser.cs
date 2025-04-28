namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Large Pulse Laser weapon.
/// </summary>
public sealed class Largepulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Largepulselaser"/> class.
    /// </summary>
    public Largepulselaser() : base("Large Pulse Laser", 2, 6.0m, 10, 0, 6, 14, 20, 10, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
