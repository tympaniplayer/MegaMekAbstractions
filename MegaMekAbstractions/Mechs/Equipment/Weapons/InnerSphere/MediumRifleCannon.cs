namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Medium Rifle (Cannon) weapon.
/// </summary>
public sealed class MediumRifleCannon : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediumRifleCannon"/> class.
    /// </summary>
    public MediumRifleCannon() : base("Medium Rifle (Cannon)", 2, 5.0m, 2, 1, 5, 10, 15, 6, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 9;
    }
}
