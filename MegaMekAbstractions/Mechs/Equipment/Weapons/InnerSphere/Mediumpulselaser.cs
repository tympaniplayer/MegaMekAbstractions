namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Medium Pulse Laser weapon.
/// </summary>
public sealed class Mediumpulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mediumpulselaser"/> class.
    /// </summary>
    public Mediumpulselaser() : base("Medium Pulse Laser", 1, 2.0m, 4, 0, 2, 4, 6, 6, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
