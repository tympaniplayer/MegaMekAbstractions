namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the LB 5-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon5"/> class.
    /// </summary>
    public LBXAutoCannon5() : base("LB 5-X AC", 8, 1521.0m, 0, 5, 3, 7, 14, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 5;
    }
}
