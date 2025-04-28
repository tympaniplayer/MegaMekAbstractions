namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ProtoMech AC/4 weapon.
/// </summary>
public sealed class ProtoMechAutoCannon4 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProtoMechAutoCannon4"/> class.
    /// </summary>
    public ProtoMechAutoCannon4() : base("ProtoMech AC/4", 45, 1115.0m, 0, 4, 0, 5, 10, 1, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 3;
    }
}
