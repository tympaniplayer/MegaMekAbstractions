namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LB 10-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon10"/> class.
    /// </summary>
    public LBXAutoCannon10() : base("LB 10-X AC", 5, 10.0m, 2, 0, 6, 12, 18, 10, DamageTypeFlags.DirectFireBallistic SwitchableAmmo)
    {
        ShotsPerTon = 10;
    }
}
