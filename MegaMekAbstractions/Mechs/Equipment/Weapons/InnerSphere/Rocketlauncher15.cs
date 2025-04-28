namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Rocket Launcher 15 weapon.
/// </summary>
public sealed class Rocketlauncher15 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rocketlauncher15"/> class.
    /// </summary>
    public Rocketlauncher15() : base("Rocket Launcher 15", 59, 14.0m, 0, 4, 1, 515, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1015;
    }
}
