namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Active Probe weapon.
/// </summary>
public sealed class ActiveProbe : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ActiveProbe"/> class.
    /// </summary>
    public ActiveProbe() : base("Active Probe", 05, 3.0m, 0, 0, 0, 0, 0, 0, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 1;
    }
}
