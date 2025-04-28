namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER Flamer weapon.
/// </summary>
public sealed class ERFlamer : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ERFlamer"/> class.
    /// </summary>
    public ERFlamer() : base("ER Flamer", 67, 45.0m, 0, 4, 2, 0, 3, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
