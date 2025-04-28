namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the ECM Suite weapon.
/// </summary>
public sealed class Ecmsuite : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ecmsuite"/> class.
    /// </summary>
    public Ecmsuite() : base("ECM Suite", 2, 6.0m, 0, 0, 0, 0, 0, 0, DamageTypeFlags.DirectFireBallistic)
    {
        ShotsPerTon = 2;
    }
}
