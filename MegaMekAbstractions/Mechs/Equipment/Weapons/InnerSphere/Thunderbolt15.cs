namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Thunderbolt 15 weapon.
/// </summary>
public sealed class Thunderbolt15 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Thunderbolt15"/> class.
    /// </summary>
    public Thunderbolt15() : base("Thunderbolt 15", 3, 11.0m, 7, 5, 6, 12, 18, 15, DamageTypeFlags.Missile)
    {
        ShotsPerTon = 4;
    }
}
