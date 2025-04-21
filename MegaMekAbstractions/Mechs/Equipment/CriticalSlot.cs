using System.Collections.ObjectModel;

namespace MegaMekAbstractions.Mechs.Equipment;

/// <summary>
/// Represents a critical slot in a mech location
/// </summary>
public class CriticalSlot
{
    /// <summary>
    /// Gets or sets the equipment in this slot
    /// </summary>
    public MechEquipment? Equipment { get; set; }
    
    /// <summary>
    /// Gets or sets whether this is the first slot of multi-slot equipment
    /// </summary>
    public bool IsFirst { get; set; }
    
    /// <summary>
    /// Gets or sets whether the slot has been hit/damaged
    /// </summary>
    public bool IsDamaged { get; set; }
}

/// <summary>
/// Represents all critical slots in a mech location
/// </summary>
public class LocationCriticals
{
    /// <summary>
    /// Gets the location these critical slots belong to
    /// </summary>
    public Location Location { get; }
    
    /// <summary>
    /// Gets the critical slots in this location
    /// </summary>
    public ReadOnlyCollection<CriticalSlot> Slots { get; }
    
    /// <summary>
    /// Creates a new LocationCriticals instance
    /// </summary>
    /// <param name="location">The location these slots belong to</param>
    /// <param name="slotCount">Number of critical slots in this location</param>
    public LocationCriticals(Location location, int slotCount)
    {
        Location = location;
        var slots = new List<CriticalSlot>(slotCount);
        for (int i = 0; i < slotCount; i++)
        {
            slots.Add(new CriticalSlot());
        }
        Slots = new ReadOnlyCollection<CriticalSlot>(slots);
    }
    
    /// <summary>
    /// Gets equipment installed in this location
    /// </summary>
    public IEnumerable<MechEquipment> GetEquipment()
    {
        var equipment = new HashSet<MechEquipment>();
        foreach (var slot in Slots)
        {
            if (slot.Equipment != null && slot.IsFirst)
            {
                equipment.Add(slot.Equipment);
            }
        }
        return equipment;
    }
    
    /// <summary>
    /// Checks if there's room to install equipment
    /// </summary>
    /// <param name="slotsNeeded">Number of consecutive slots needed</param>
    /// <returns>True if there's room, false otherwise</returns>
    public bool HasRoom(int slotsNeeded)
    {
        int consecutive = 0;
        foreach (var slot in Slots)
        {
            if (slot.Equipment == null)
            {
                consecutive++;
                if (consecutive >= slotsNeeded)
                {
                    return true;
                }
            }
            else
            {
                consecutive = 0;
            }
        }
        return false;
    }
}
