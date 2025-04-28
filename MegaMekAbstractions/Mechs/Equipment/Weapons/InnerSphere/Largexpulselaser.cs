namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Large X-Pulse Laser weapon.
/// </summary>
public sealed class Largexpulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Largexpulselaser"/> class.
    /// </summary>
    public Largexpulselaser() : base("Large X-Pulse Laser", 2, 7.0m, 14, 0, 5, 10, 15, 9, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
