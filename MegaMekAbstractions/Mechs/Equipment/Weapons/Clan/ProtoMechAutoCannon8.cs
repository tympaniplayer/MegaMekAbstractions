namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ProtoMech AC/8 weapon.
/// </summary>
public sealed class ProtoMechAutoCannon8 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProtoMechAutoCannon8"/> class.
    /// </summary>
    public ProtoMechAutoCannon8() : base("ProtoMech AC/8", 55, 810.0m, 0, 8, 0, 3, 7, 2, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 4;
    }
}
