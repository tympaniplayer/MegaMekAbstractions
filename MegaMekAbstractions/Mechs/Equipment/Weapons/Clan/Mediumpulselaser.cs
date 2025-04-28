namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Medium Pulse Laser weapon.
/// </summary>
public sealed class Mediumpulselaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mediumpulselaser"/> class.
    /// </summary>
    public Mediumpulselaser() : base("Medium Pulse Laser", 1, 2.0m, 4, 0, 4, 8, 12, 7, DamageTypeFlags.Pulse)
    {
        ShotsPerTon = 0;
    }
}
