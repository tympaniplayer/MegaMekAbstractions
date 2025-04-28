namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Vibroblade weapon.
/// </summary>
public sealed class Vibroblade : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Vibroblade"/> class.
    /// </summary>
    public Vibroblade() : base("Vibroblade", 7, 0.0m, 0, 14, 0, 0, 0, 7, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 4;
    }
}
