namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Ultra AC/5 weapon.
/// </summary>
public sealed class UltraAutoCannon5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UltraAutoCannon5"/> class.
    /// </summary>
    public UltraAutoCannon5() : base("Ultra AC/5", 1420, 713.0m, 0, 5, 2, 2, 6, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 9;
    }
}
