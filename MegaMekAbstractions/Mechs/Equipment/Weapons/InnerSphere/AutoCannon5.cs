namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Autocannon/5 weapon.
/// </summary>
public sealed class AutoCannon5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoCannon5"/> class.
    /// </summary>
    public AutoCannon5() : base("Autocannon/5", 8, 1318.0m, 0, 5, 3, 6, 12, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 4;
    }
}
