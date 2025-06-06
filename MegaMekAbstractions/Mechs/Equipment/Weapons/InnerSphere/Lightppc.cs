namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Light PPC weapon.
/// </summary>
public sealed class Lightppc : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Lightppc"/> class.
    /// </summary>
    public Lightppc() : base("Light PPC", 2, 3.0m, 5, 3, 6, 12, 18, 5, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
