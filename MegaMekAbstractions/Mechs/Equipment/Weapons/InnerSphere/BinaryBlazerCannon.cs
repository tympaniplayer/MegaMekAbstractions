namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Binary (Blazer) Cannon weapon.
/// </summary>
public sealed class BinaryBlazerCannon : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryBlazerCannon"/> class.
    /// </summary>
    public BinaryBlazerCannon() : base("Binary (Blazer) Cannon", 4, 9.0m, 16, 0, 5, 10, 15, 12, DamageTypeFlags.DirectFireEnergy | DamageTypeFlags.Electronics)
    {
        ShotsPerTon = 0;
    }
}
