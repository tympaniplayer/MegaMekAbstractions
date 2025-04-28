namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the M-Pod weapon.
/// </summary>
public sealed class Mpod : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mpod"/> class.
    /// </summary>
    public Mpod() : base("M-Pod", 2, 1.0m, 0, 0, 0, 151051, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 3;
    }
}
