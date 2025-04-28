namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Ultra AC/2 weapon.
/// </summary>
public sealed class UltraAutoCannon2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UltraAutoCannon2"/> class.
    /// </summary>
    public UltraAutoCannon2() : base("Ultra AC/2", 1825, 917.0m, 0, 2, 2, 3, 8, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 7;
    }
}
