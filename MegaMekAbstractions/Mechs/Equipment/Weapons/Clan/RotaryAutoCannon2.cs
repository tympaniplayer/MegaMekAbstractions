namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Rotary AC/2 weapon.
/// </summary>
public sealed class RotaryAutoCannon2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RotaryAutoCannon2"/> class.
    /// </summary>
    public RotaryAutoCannon2() : base("Rotary AC/2", 1825, 917.0m, 0, 2, 6, 0, 8, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 8;
    }
}
