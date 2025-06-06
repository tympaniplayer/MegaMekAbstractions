namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LB 20-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon20"/> class.
    /// </summary>
    public LBXAutoCannon20() : base("LB 20-X AC", 9, 12.0m, 6, 0, 4, 8, 12, 20, DamageTypeFlags.DirectFireBallistic | DamageTypeFlags.SwitchableAmmo)
    {
        ShotsPerTon = 5;
    }
}
