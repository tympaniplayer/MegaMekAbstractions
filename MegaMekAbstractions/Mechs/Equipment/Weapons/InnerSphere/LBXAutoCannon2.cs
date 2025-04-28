namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the LB 2-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon2"/> class.
    /// </summary>
    public LBXAutoCannon2() : base("LB 2-X AC", 6, 1927.0m, 0, 2, 4, 9, 18, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 4;
    }
}
