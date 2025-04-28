namespace MegaMekAbstractions.Mechs.Equipment.Weapons.InnerSphere;

/// <summary>
/// Represents the PPC weapon.
/// </summary>
public sealed class PPC : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PPC"/> class.
    /// </summary>
    public PPC() : base("PPC", 3, 7.0m, 10, 3, 6, 12, 18, 10, DamageTypeFlags.DirectFireEnergy)
    {
        ShotsPerTon = 0;
    }
}
