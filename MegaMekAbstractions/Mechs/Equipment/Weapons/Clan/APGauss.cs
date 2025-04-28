namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the AP Gauss Rifle weapon.
/// </summary>
public sealed class APGauss : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="APGauss"/> class.
    /// </summary>
    public APGauss() : base("AP Gauss Rifle", 79, 46.0m, 0, 1, 3, 0, 3, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 05;
    }
}
