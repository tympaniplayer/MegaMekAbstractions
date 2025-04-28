namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Enhanced LRM 5 weapon.
/// </summary>
public sealed class Enhancedlrm5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Enhancedlrm5"/> class.
    /// </summary>
    public Enhancedlrm5() : base("Enhanced LRM 5", 814, 17.0m, 0, 2, 1, 55, 3, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1521;
    }
}
