namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the LB 2-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon2"/> class.
    /// </summary>
    public LBXAutoCannon2() : base("LB 2-X AC", 3, 5.0m, 1, 4, 10, 20, 30, 2, DamageTypeFlags.DirectFireBallistic | DamageTypeFlags.SwitchableAmmo)
    {
        ShotsPerTon = 45;
    }
}
