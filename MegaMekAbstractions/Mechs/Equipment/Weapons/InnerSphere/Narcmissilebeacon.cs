namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Narc Missile Beacon weapon.
/// </summary>
public sealed class Narcmissilebeacon : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Narcmissilebeacon"/> class.
    /// </summary>
    public Narcmissilebeacon() : base("Narc Missile Beacon", 3, 79.0m, 0, 0, 0, 3, 6, 0, DamageTypeFlags.Missile)
    {
        ShotsPerTon = 2;
    }
}
