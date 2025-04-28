namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ProtoMech AC/2 weapon.
/// </summary>
public sealed class ProtoMechAutoCannon2 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProtoMechAutoCannon2"/> class.
    /// </summary>
    public ProtoMechAutoCannon2() : base("ProtoMech AC/2", 35, 1520.0m, 0, 2, 0, 7, 14, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 2;
    }
}
