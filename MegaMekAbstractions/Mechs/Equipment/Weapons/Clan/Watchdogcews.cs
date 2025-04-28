namespace MegaMekAbstractions.Mechs.Equipment.Weapons.Clan;

/// <summary>
/// Represents the Watchdog CEWS weapon.
/// </summary>
public sealed class Watchdogcews : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Watchdogcews"/> class.
    /// </summary>
    public Watchdogcews() : base("Watchdog CEWS", 2, 1.5.0m, 0, 0, 0, 0, 3, 0, DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
