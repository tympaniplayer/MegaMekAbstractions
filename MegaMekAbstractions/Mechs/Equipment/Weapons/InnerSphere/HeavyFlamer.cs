namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Heavy Flamer weapon.
/// </summary>
public sealed class HeavyFlamer : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeavyFlamer"/> class.
    /// </summary>
    public HeavyFlamer() : base("Heavy Flamer", 4, 3.0m, 0, 5, 4, 0, 2, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 15;
    }
}
