namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Light Rifle (Cannon) weapon.
/// </summary>
public sealed class LightRifleCannon : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LightRifleCannon"/> class.
    /// </summary>
    public LightRifleCannon() : base("Light Rifle (Cannon)", 1, 3.0m, 1, 0, 4, 8, 12, 3, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 18;
    }
}
