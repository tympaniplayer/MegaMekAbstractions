namespace MegaMekAbstractions.Mechs.Equipment;

/// <summary>
/// Represents a weapon system
/// </summary>
public abstract class Weapon : MechEquipment
{
    /// <summary>
    /// Gets or sets the minimum range of the weapon
    /// </summary>
    public int MinimumRange { get; protected set; }

    /// <summary>
    /// Gets or sets the weapon's short range
    /// </summary>
    public int ShortRange { get; protected set; }

    /// <summary>
    /// Gets or sets the weapon's medium range
    /// </summary>
    public int MediumRange { get; protected set; }

    /// <summary>
    /// Gets or sets the weapon's long range
    /// </summary>
    public int LongRange { get; protected set; }

    /// <summary>
    /// Gets or sets the weapon's damage
    /// </summary>
    public int Damage { get; protected set; }

    /// <summary>
    /// Gets or sets the damage type flags for the weapon.
    /// </summary>
    public DamageTypeFlags DamageTypeFlags { get; protected set; }
    
    /// <summary>
    /// Gets or sets the number of shots per ton for the weapon
    /// </summary>
    public int ShotsPerTon { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Weapon"/> class.
    /// </summary>
    protected Weapon(
        string name,
        int criticalSlots,
        decimal tonnage,
        int heat,
        int minimumRange,
        int shortRange,
        int mediumRange,
        int longRange,
        int damage,
        DamageTypeFlags damageTypeFlags)
        : base(name, criticalSlots, tonnage, heat)
    {
        MinimumRange = minimumRange;
        ShortRange = shortRange;
        MediumRange = mediumRange;
        LongRange = longRange;
        Damage = damage;
        DamageTypeFlags = damageTypeFlags;
        ShotsPerTon = 0;
    }
}
