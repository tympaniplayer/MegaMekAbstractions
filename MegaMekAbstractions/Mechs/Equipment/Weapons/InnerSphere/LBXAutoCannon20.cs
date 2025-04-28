namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the LB 20-X AC weapon.
/// </summary>
public sealed class LBXAutoCannon20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LBXAutoCannon20"/> class.
    /// </summary>
    public LBXAutoCannon20() : base("LB 20-X AC", 14, 912.0m, 0, 20, 0, 4, 8, 6, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 11;
    }
}
