namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Autocannon/2 weapon.
/// </summary>
public sealed class AutoCannon2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoCannon2"/> class.
    /// </summary>
    public AutoCannon2() : base("Autocannon/2", 1, 6.0m, 1, 4, 8, 16, 24, 2, DamageTypeFlags.DirectFireBallistic | DamageTypeFlags.SwitchableAmmo)
    {
        ShotsPerTon = 45;
    }
}
