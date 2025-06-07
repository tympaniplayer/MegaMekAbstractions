namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the MML 3 weapon.
/// </summary>
public sealed class Mml3 : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Mml3"/> class.
    /// </summary>
    public Mml3() : base("MML 3", 1, 0.0m, 0, 1, 0, 0, 0, 0, DamageTypeFlags.Cluster)
    {
        ShotsPerTon = 2;
    }
}
