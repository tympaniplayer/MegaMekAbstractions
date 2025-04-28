namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LB 5-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon5"/> class.
    /// </summary>
    public LBXAutoCannon5() : base("LB 5-X AC", 4, 7.0m, 1, 3, 8, 15, 24, 5, DamageTypeFlags.DirectFireBallistic SwitchableAmmo)
    {
        ShotsPerTon = 20;
    }
}
