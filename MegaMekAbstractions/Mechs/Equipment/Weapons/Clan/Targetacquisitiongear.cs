namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Target Acquisition Gear (TAG) weapon.
/// </summary>
public sealed class Targetacquisitiongear : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Targetacquisitiongear"/> class.
    /// </summary>
    public Targetacquisitiongear() : base("Target Acquisition Gear (TAG)", 1, 1.0m, 0, 0, 5, 9, 15, 0, DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
