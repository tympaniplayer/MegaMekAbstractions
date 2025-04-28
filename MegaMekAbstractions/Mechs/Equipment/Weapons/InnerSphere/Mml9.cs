namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MML 9 weapon.
/// </summary>
public sealed class Mml9 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mml9"/> class.
    /// </summary>
    public Mml9() : base("MML 9", 1, 0.0m, 0, 6, 0, 0, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 5;
    }
}
