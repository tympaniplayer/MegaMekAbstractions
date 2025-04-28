namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Plasma Rifle weapon.
/// </summary>
public sealed class PlasmaRifle : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlasmaRifle"/> class.
    /// </summary>
    public PlasmaRifle() : base("Plasma Rifle", 6, 1115.0m, 0, 10, 0, 5, 10, 10, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 2;
    }
}
