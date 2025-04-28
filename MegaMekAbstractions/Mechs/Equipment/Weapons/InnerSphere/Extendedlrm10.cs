namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Extended LRM 10 weapon.
/// </summary>
public sealed class Extendedlrm10 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Extendedlrm10"/> class.
    /// </summary>
    public Extendedlrm10() : base("Extended LRM 10", 2338, 1322.0m, 0, 1, 510, 10, 12, 6, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 8;
    }
}
