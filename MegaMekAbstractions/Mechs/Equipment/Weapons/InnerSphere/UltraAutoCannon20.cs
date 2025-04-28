namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Ultra AC/20 weapon.
/// </summary>
public sealed class UltraAutoCannon20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UltraAutoCannon20"/> class.
    /// </summary>
    public UltraAutoCannon20() : base("Ultra AC/20", 810, 47.0m, 0, 20, 2, 0, 3, 8, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 15;
    }
}
