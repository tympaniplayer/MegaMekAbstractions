namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Arrow IV weapon.
/// </summary>
public sealed class Arrowiv : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Arrowiv"/> class.
    /// </summary>
    public Arrowiv() : base("Arrow IV", 12, 12.0m, 10, 0, 0, 0, 0, 20, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 5;
    }
}
