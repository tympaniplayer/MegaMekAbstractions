namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Heavy Small Laser weapon.
/// </summary>
public sealed class Heavysmalllaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heavysmalllaser"/> class.
    /// </summary>
    public Heavysmalllaser() : base("Heavy Small Laser", 1, 0.5.0m, 3, 0, 1, 2, 3, 6, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
