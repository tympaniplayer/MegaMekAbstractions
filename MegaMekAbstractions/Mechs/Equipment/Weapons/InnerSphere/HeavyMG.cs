namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Heavy Machine Gun weapon.
/// </summary>
public sealed class HeavyMG : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeavyMG"/> class.
    /// </summary>
    public HeavyMG() : base("Heavy Machine Gun", 1, 0.0m, 0, 3, 0, 1, 2, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
