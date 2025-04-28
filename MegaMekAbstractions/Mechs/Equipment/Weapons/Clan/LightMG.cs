namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Light Machine Gun weapon.
/// </summary>
public sealed class LightMG : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LightMG"/> class.
    /// </summary>
    public LightMG() : base("Light Machine Gun", 025, 56.0m, 0, 1, 0, 2, 4, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
