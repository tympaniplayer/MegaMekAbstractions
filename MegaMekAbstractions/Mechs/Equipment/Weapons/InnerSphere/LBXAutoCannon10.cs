namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the LB 10-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon10"/> class.
    /// </summary>
    public LBXAutoCannon10() : base("LB 10-X AC", 11, 1318.0m, 0, 10, 0, 6, 12, 2, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 6;
    }
}
