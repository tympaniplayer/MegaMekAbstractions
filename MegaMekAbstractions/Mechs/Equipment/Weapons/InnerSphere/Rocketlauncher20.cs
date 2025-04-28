namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Rocket Launcher 20 weapon.
/// </summary>
public sealed class Rocketlauncher20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rocketlauncher20"/> class.
    /// </summary>
    public Rocketlauncher20() : base("Rocket Launcher 20", 47, 13.0m, 0, 5, 1, 520, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 812;
    }
}
