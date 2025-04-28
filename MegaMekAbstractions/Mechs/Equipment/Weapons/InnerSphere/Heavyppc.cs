namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Heavy PPC weapon.
/// </summary>
public sealed class Heavyppc : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heavyppc"/> class.
    /// </summary>
    public Heavyppc() : base("Heavy PPC", 4, 10.0m, 15, 3, 6, 12, 18, 15, DamageTypeFlags.DirectFireEnergy Electronics)
    {
        ShotsPerTon = 0;
    }
}
