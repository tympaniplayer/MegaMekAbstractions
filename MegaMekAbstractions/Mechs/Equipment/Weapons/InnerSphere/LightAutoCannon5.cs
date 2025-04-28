namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Light AC/5 weapon.
/// </summary>
public sealed class LightAutoCannon5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LightAutoCannon5"/> class.
    /// </summary>
    public LightAutoCannon5() : base("Light AC/5", 5, 1115.0m, 0, 5, 0, 5, 10, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 2;
    }
}
