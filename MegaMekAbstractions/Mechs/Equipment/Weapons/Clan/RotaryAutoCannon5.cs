namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Rotary AC/5 weapon.
/// </summary>
public sealed class RotaryAutoCannon5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RotaryAutoCannon5"/> class.
    /// </summary>
    public RotaryAutoCannon5() : base("Rotary AC/5", 1521, 814.0m, 0, 5, 6, 0, 7, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 10;
    }
}
