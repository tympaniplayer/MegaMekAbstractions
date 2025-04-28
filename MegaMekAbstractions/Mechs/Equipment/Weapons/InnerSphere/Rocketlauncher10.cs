namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Rocket Launcher 10 weapon.
/// </summary>
public sealed class Rocketlauncher10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rocketlauncher10"/> class.
    /// </summary>
    public Rocketlauncher10() : base("Rocket Launcher 10", 611, 15.0m, 0, 3, 1, 510, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1218;
    }
}
