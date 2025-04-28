namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the Enhanced LRM 20 weapon.
/// </summary>
public sealed class Enhancedlrm20 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Enhancedlrm20"/> class.
    /// </summary>
    public Enhancedlrm20() : base("Enhanced LRM 20", 814, 17.0m, 0, 6, 1, 520, 3, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 1521;
    }
}
