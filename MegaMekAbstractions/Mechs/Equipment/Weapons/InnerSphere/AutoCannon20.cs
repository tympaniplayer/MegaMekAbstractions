namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Autocannon/20 weapon.
/// </summary>
public sealed class AutoCannon20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoCannon20"/> class.
    /// </summary>
    public AutoCannon20() : base("Autocannon/20", 14, 79.0m, 0, 20, 0, 3, 6, 7, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 10;
    }
}
