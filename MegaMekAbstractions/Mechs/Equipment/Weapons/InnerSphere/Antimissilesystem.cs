namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Anti-Missile System weapon.
/// </summary>
public sealed class Antimissilesystem : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Antimissilesystem"/> class.
    /// </summary>
    public Antimissilesystem() : base("Anti-Missile System", 15, 0.0m, 0, 0, 0, 0, 0, 7, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 2;
    }
}
