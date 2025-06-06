namespace MegaMekAbstractions.Mechs.Equipment;

/// <summary>
/// Represents ammunition for weapons
/// </summary>
public class Ammunition : MechEquipment
{
    /// <summary>
    /// Gets or sets the type of ammunition
    /// </summary>
    public string AmmoType { get; set; }

    /// <summary>
    /// Gets or sets the number of shots
    /// </summary>
    public int ShotsPerTon { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Ammunition"/> class.
    /// </summary>
    public Ammunition()
        : base(string.Empty, 0, 0m, 0)
    {
        AmmoType = string.Empty;
        ShotsPerTon = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Ammunition"/> class.
    /// </summary>
    /// <param name="name">Display name of the ammunition.</param>
    /// <param name="criticalSlots">How many critical slots the ammo occupies.</param>
    /// <param name="tonnage">Tonnage of the ammo.</param>
    /// <param name="heat">Heat generated (usually zero).</param>
    /// <param name="ammoType">Ammo type description.</param>
    /// <param name="shotsPerTon">How many shots each ton provides.</param>
    public Ammunition(
        string name,
        int criticalSlots,
        decimal tonnage,
        int heat,
        string ammoType,
        int shotsPerTon)
        : base(name, criticalSlots, tonnage, heat)
    {
        AmmoType = ammoType;
        ShotsPerTon = shotsPerTon;
    }
}
