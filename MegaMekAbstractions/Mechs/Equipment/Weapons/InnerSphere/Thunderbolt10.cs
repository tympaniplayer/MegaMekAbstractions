namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Thunderbolt 10 weapon.
/// </summary>
public sealed class Thunderbolt10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Thunderbolt10"/> class.
    /// </summary>
    public Thunderbolt10() : base("Thunderbolt 10", 2, 7.0m, 5, 5, 6, 12, 18, 10, DamageTypeFlags.Missile)
    {
        ShotsPerTon = 6;
    }
}
