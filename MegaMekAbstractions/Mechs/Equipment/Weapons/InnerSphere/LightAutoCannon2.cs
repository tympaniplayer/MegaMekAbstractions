namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Light AC/2 weapon.
/// </summary>
public sealed class LightAutoCannon2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LightAutoCannon2"/> class.
    /// </summary>
    public LightAutoCannon2() : base("Light AC/2", 4, 1318.0m, 0, 2, 0, 6, 12, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 1;
    }
}
