namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Thunderbolt 20 weapon.
/// </summary>
public sealed class Thunderbolt20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Thunderbolt20"/> class.
    /// </summary>
    public Thunderbolt20() : base("Thunderbolt 20", 5, 15.0m, 8, 5, 6, 12, 18, 20, DamageTypeFlags.Missile)
    {
        ShotsPerTon = 3;
    }
}
