namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Heavy Medium Laser weapon.
/// </summary>
public sealed class Heavymediumlaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heavymediumlaser"/> class.
    /// </summary>
    public Heavymediumlaser() : base("Heavy Medium Laser", 2, 1.0m, 7, 0, 3, 6, 9, 10, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
