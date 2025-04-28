namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Snub-Nose PPC weapon.
/// </summary>
public sealed class Snubnoseppc : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Snubnoseppc"/> class.
    /// </summary>
    public Snubnoseppc() : base("Snub-Nose PPC", 6, 1415.0m, 0, 1085, 0, 9, 13, 10, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 2;
    }
}
