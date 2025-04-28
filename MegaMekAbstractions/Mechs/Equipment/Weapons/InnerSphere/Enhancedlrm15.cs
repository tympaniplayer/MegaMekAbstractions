namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Enhanced LRM 15 weapon.
/// </summary>
public sealed class Enhancedlrm15 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Enhancedlrm15"/> class.
    /// </summary>
    public Enhancedlrm15() : base("Enhanced LRM 15", 814, 17.0m, 0, 5, 1, 515, 3, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1521;
    }
}
