namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Improved Narc Launcher weapon.
/// </summary>
public sealed class ImprovedNarcLauncher : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImprovedNarcLauncher"/> class.
    /// </summary>
    public ImprovedNarcLauncher() : base("Improved Narc Launcher", 5, 1015.0m, 0, 0, 0, 4, 9, 0, DamageTypeFlags.Missile)
    {
        ShotsPerTon = 3;
    }
}
