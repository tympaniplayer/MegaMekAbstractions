namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Chemical Laser weapon.
/// </summary>
public sealed class ChemicalLaser : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChemicalLaser"/> class.
    /// </summary>
    public ChemicalLaser() : base("Chemical Laser", 5, 1115.0m, 0, 8, 0, 5, 10, 6, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 2;
    }
}
