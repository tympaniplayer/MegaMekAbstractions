using System.Collections.ObjectModel;
using MegaMekAbstractions.Common;
using MegaMekAbstractions.Mechs.Equipment;

namespace MegaMekAbstractions.Mechs;

/// <summary>
/// Represents a complete BattleMech
/// </summary>
public class Mech
{
    // Basic Information
    public required string Chassis { get; set; }
    public required string Model { get; set; }
    public int MulId { get; set; }
    public Configuration Configuration { get; set; }
    public TechBase TechBase { get; set; }
    public int Era { get; set; }
    public required string Source { get; set; }
    public RulesLevel RulesLevel { get; set; }
    public GroundRole GroundRole { get; set; }
    public required IList<Quirk> Quirks { get; set; }
    public int Mass { get; set; }

    // Extended metadata from newer MTF files
    public string Myomer { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string PrimaryFactory { get; set; } = string.Empty;
    public Dictionary<string, string> SystemManufacturers { get; set; } = new();
    public string Overview { get; set; } = string.Empty;
    public string Capabilities { get; set; } = string.Empty;
    public string Deployment { get; set; } = string.Empty;
    public string History { get; set; } = string.Empty;

    // Core Systems
    public required Engine Engine { get; set; }
    public required Gyro Gyro { get; set; }
    public required Cockpit Cockpit { get; set; }
    public required HeatSinks HeatSinks { get; set; }

    // Structure and Armor
    public required StructureValues Structure { get; set; }
    public required ArmorValues Armor { get; set; }

    // Equipment and Weapons
    private readonly Dictionary<Location, LocationCriticals> _criticals;
    public IReadOnlyDictionary<Location, LocationCriticals> Criticals => _criticals;

    public Mech()
    {
        _criticals = new Dictionary<Location, LocationCriticals>();
        foreach (Location location in Enum.GetValues<Location>())
        {
            // Skip rear locations as they don't have critical slots
            if (location is Location.CenterTorsoRear or Location.LeftTorsoRear or Location.RightTorsoRear)
                continue;

            int slotCount = location switch
            {
                Location.Head => 6,
                Location.CenterTorso => 12,
                Location.LeftTorso => 12,
                Location.RightTorso => 12,
                Location.LeftArm => 12,
                Location.RightArm => 12,
                Location.LeftLeg => 6,
                Location.RightLeg => 6,
                _ => 0
            };

            if (slotCount > 0)
            {
                _criticals[location] = new LocationCriticals(location, slotCount);
            }
        }
    }

    /// <summary>
    /// Gets all equipment installed on the mech
    /// </summary>
    public IEnumerable<MechEquipment> GetAllEquipment()
    {
        return _criticals.Values.SelectMany(loc => loc.GetEquipment());
    }

    /// <summary>
    /// Gets equipment installed in a specific location
    /// </summary>
    public IEnumerable<MechEquipment> GetEquipment(Location location)
    {
        return _criticals.TryGetValue(location, out var criticals)
            ? criticals.GetEquipment()
            : Enumerable.Empty<MechEquipment>();
    }
    
    
    public static Gyro ToGyro(string gyro)
    {
        return gyro switch
        {
            "Standard Gyro" or "Standard" => Gyro.Standard,
            "XL Gyro" or "XL"  => Gyro.XL,
            "Compact Gyro" or "Compact" => Gyro.Compact,
            "Heavy Duty Gyro" or "Heavy Duty" => Gyro.HeavyDuty,
            "Superheavy Gyro" or "Superheavy" => Gyro.SuperHeavy,
            "None" => Gyro.None,
            _ => Gyro.Unknown
        };
    }
    public static Cockpit ToCockpit(string cockpit)
    {
        return cockpit switch
        {
            "Standard Cockpit" or "Standard" => Cockpit.Standard,
            "Small Cockpit" or "Small" => Cockpit.Small,
            "Command Console" or "Command" => Cockpit.CommandConsole,
            "Torso-Mounted Cockpit" or "Torso-Mounted" => Cockpit.TorsoMounted,
            "Dual Cockpit" or "Dual" => Cockpit.Dual,
            "Industrial Cockpit" or "Industrial" => Cockpit.Industrial,
            "Primitive Cockpit" or "Primitive" => Cockpit.Primitive,
            "Primitive Industrial Cockpit" or "Primitive Industrial" => Cockpit.PrimitiveIndustrial,
            "Superheavy Cockpit" or "Super Heavy" => Cockpit.Superheavy,
            "Superheavy Tripod Cockpit" or "Superheavy Tripod" => Cockpit.SuperheavyTripod,
            "Tripod Cockpit" or "Tripod" => Cockpit.Tripod,
            "Interface Cockpit" or "Interface" => Cockpit.Interface,
            "Virtual Reality Piloting Pod" or "VRRP" => Cockpit.Vrpp,
            "Quadvee Cockpit" or "Quadvee" => Cockpit.Quadvee,
            "Superheavy Industrial Cockpit" or "Superheavy Industrial" => Cockpit.SuperheavyIndustrial,
            "Superheavy Command Console" or "Superheavy Command" => Cockpit.SuperheavyCommandConsole,
            "Small Command Console" or "Small Command" => Cockpit.SmallCommandConsole,
            "Tripod Industrial Cockpit" or "Tripod Industrial" => Cockpit.TripodIndustrial,
            "Superheavy Tripod Industrial Cockpit" or "Superheavy Tripod Industrial" => Cockpit.SuperheavyTripodIndustrial,
            _ => Cockpit.Unknown
        };
    }
}
