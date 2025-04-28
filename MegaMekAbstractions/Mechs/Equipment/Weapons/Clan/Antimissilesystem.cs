namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Anti-Missile System weapon.
/// </summary>
public sealed class Antimissilesystem : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Antimissilesystem"/> class.
    /// </summary>
    public Antimissilesystem() : base("Anti-Missile System", 1, 0.0m, 0, 0, 0, 0, 0, 5, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 1;
    }
}
