namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Thunderbolt 5 weapon.
/// </summary>
public sealed class Thunderbolt5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Thunderbolt5"/> class.
    /// </summary>
    public Thunderbolt5() : base("Thunderbolt 5", 1, 3.0m, 3, 5, 6, 12, 18, 5, DamageTypeFlags.Missile)
    {
        ShotsPerTon = 12;
    }
}
