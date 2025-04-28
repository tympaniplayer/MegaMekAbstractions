namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Plasma Cannon weapon.
/// </summary>
public sealed class PlasmaCannon : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlasmaCannon"/> class.
    /// </summary>
    public PlasmaCannon() : base("Plasma Cannon", 3, 1318.0m, 0, 0, 0, 6, 12, 7, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 1;
    }
}
