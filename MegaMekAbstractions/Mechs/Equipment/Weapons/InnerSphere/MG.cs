namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Machine Gun weapon.
/// </summary>
public sealed class MG : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MG"/> class.
    /// </summary>
    public MG() : base("Machine Gun", 05, 3.0m, 0, 2, 0, 1, 2, 0, DamageTypeFlags.AntiInfantry)
    {
        ShotsPerTon = 1;
    }
}
