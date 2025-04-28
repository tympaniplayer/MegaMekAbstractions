namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MML 7 weapon.
/// </summary>
public sealed class Mml7 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mml7"/> class.
    /// </summary>
    public Mml7() : base("MML 7", 1, 0.0m, 0, 4.5, 0, 0, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 4;
    }
}
