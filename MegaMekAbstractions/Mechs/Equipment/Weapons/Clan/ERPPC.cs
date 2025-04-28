namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ER PPC weapon.
/// </summary>
public sealed class ERPPC : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ERPPC"/> class.
    /// </summary>
    public ERPPC() : base("ER PPC", 2, 6.0m, 15, 0, 7, 14, 23, 15, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
