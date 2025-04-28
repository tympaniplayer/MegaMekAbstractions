namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Narc Missile Beacon weapon.
/// </summary>
public sealed class Narcmissilebeacon : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Narcmissilebeacon"/> class.
    /// </summary>
    public Narcmissilebeacon() : base("Narc Missile Beacon", 2, 912.0m, 0, 0, 0, 4, 8, 0, DamageTypeFlags.Missile)
    {
        ShotsPerTon = 1;
    }
}
