namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Large Pulse Laser weapon.
/// </summary>
public sealed class Largepulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Largepulselaser"/> class.
    /// </summary>
    public Largepulselaser() : base("Large Pulse Laser", 2, 7.0m, 10, 0, 3, 7, 10, 9, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
