namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Extended LRM 15 weapon.
/// </summary>
public sealed class Extendedlrm15 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Extendedlrm15"/> class.
    /// </summary>
    public Extendedlrm15() : base("Extended LRM 15", 2338, 1322.0m, 0, 1, 515, 10, 12, 8, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 12;
    }
}
