namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Ultra AC/10 weapon.
/// </summary>
public sealed class UltraAutoCannon10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UltraAutoCannon10"/> class.
    /// </summary>
    public UltraAutoCannon10() : base("Ultra AC/10", 1318, 712.0m, 0, 10, 2, 0, 6, 3, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 10;
    }
}
