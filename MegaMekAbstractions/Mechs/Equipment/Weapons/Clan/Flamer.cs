namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Flamer weapon.
/// </summary>
public sealed class Flamer : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Flamer"/> class.
    /// </summary>
    public Flamer() : base("Flamer", 3, 2.0m, 0, 3, 2, 0, 1, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 05;
    }
}
