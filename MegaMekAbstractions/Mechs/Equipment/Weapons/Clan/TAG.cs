namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the TAG weapon.
/// </summary>
public sealed class TAG : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TAG"/> class.
    /// </summary>
    public TAG() : base("TAG", 05, 79.0m, 0, 0, 0, 3, 6, 0, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 1;
    }
}
