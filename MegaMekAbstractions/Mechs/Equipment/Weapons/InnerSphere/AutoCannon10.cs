namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Autocannon/10 weapon.
/// </summary>
public sealed class AutoCannon10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoCannon10"/> class.
    /// </summary>
    public AutoCannon10() : base("Autocannon/10", 12, 1115.0m, 0, 10, 0, 5, 10, 3, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 7;
    }
}
