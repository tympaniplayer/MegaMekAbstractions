namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Extended LRM 20 weapon.
/// </summary>
public sealed class Extendedlrm20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Extendedlrm20"/> class.
    /// </summary>
    public Extendedlrm20() : base("Extended LRM 20", 2338, 1322.0m, 0, 1, 520, 10, 12, 10, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 18;
    }
}
