namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Extended LRM 5 weapon.
/// </summary>
public sealed class Extendedlrm5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Extendedlrm5"/> class.
    /// </summary>
    public Extendedlrm5() : base("Extended LRM 5", 2338, 1322.0m, 0, 1, 55, 10, 12, 3, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 6;
    }
}
