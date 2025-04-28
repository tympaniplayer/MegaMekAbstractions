namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Gauss Rifle weapon.
/// </summary>
public sealed class Gauss : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Gauss"/> class.
    /// </summary>
    public Gauss() : base("Gauss Rifle", 12, 1622.0m, 0, 15, 2, 7, 15, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 6;
    }
}
