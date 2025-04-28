namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MML 5 weapon.
/// </summary>
public sealed class Mml5 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mml5"/> class.
    /// </summary>
    public Mml5() : base("MML 5", 1, 0.0m, 0, 3, 0, 0, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 3;
    }
}
