using System.Text.RegularExpressions;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Mechs.Equipment;

namespace MegaMekParser.Mtf.Parsers;

/// <summary>
/// Parser for weapons and critical slots in MTF files
/// </summary>
public static class MtfWeaponAndCriticalParser
{
    // Regex for weapon entries like "Medium Laser, Left Arm"
    private static readonly Regex WeaponLocationRegex = new(@"^(.*?),\s*(.*?)$", RegexOptions.Compiled);
    
    /// <summary>
    /// Parses the weapons and critical slots from an MTF file content
    /// </summary>
    /// <param name="mtfContent">MTF file content</param>
    /// <param name="mech">Mech to update</param>
    public static void ParseWeaponsAndCriticals(string mtfContent, Mech mech)
    {
        // Split the content into lines and get sections
        string[] lines = mtfContent.Split('\n').Select(l => l.Trim()).ToArray();
            
        // First parse the Weapons section
        int weaponsIndex = Array.FindIndex(lines, l => l.StartsWith("Weapons:"));
        if (weaponsIndex >= 0)
        {
            ParseWeaponsSection(lines, weaponsIndex, mech);
        }
        
        // Parse location sections for critical slot assignments
        ParseLocationSections(lines, mech);
        
        // Calculate internal structure values based on mech tonnage
        CalculateStructureValues(mech);
    }
    
    private static void ParseWeaponsSection(string[] lines, int startIndex, Mech mech)
    {
        // Skip the first line which is "Weapons:N"
        for (int i = startIndex + 1; i < lines.Length; i++)
        {
            string line = lines[i];
            
            // Stop when we hit the next section
            if (string.IsNullOrWhiteSpace(line) || IsSectionHeader(line))
                break;
                
            var match = WeaponLocationRegex.Match(line);
            if (match.Success)
            {
                string weaponName = match.Groups[1].Value.Trim();
                string locationName = match.Groups[2].Value.Trim();
                
                Location location;
                if (TryParseLocation(locationName, out location))
                {
                    // Create weapon equipment
                    var weapon = CreateWeapon(weaponName);
                    
                    // Add to mech in the specified location
                    AddEquipmentToLocation(mech, weapon, location);
                }
            }
        }
    }
    
    private static void ParseLocationSections(string[] lines, Mech mech)
    {
        // Location section headers in MTF files
        string[] locationHeaders = new[]
        {
            "Left Arm:", "Right Arm:", "Left Torso:", "Right Torso:", 
            "Center Torso:", "Head:", "Left Leg:", "Right Leg:"
        };
        
        foreach (string header in locationHeaders)
        {
            int sectionIndex = Array.FindIndex(lines, l => l.Equals(header, StringComparison.OrdinalIgnoreCase));
            if (sectionIndex >= 0)
            {
                // Parse each location section
                Location location;
                if (TryParseLocation(header.TrimEnd(':'), out location))
                {
                    ParseLocationCriticals(lines, sectionIndex, mech, location);
                }
            }
        }
    }
    
    private static void ParseLocationCriticals(string[] lines, int startIndex, Mech mech, Location location)
    {
        // Skip the header line
        for (int i = startIndex + 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            
            // Stop when we hit the next section
            if (string.IsNullOrWhiteSpace(line) || IsSectionHeader(line))
                break;
                
            // Skip non-equipment lines like "Shoulder", "Upper Arm Actuator", etc.
            if (line.Equals("Shoulder", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Upper Arm Actuator", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Lower Arm Actuator", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Hand Actuator", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Hip", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Upper Leg Actuator", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Lower Leg Actuator", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Foot Actuator", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Life Support", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Sensors", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Cockpit", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Gyro", StringComparison.OrdinalIgnoreCase) ||
                line.Equals("Fusion Engine", StringComparison.OrdinalIgnoreCase) ||
                line.StartsWith("-Empty-", StringComparison.OrdinalIgnoreCase))
                continue;
                
            // Create equipment for this critical slot
            var equipment = CreateEquipment(line);
            if (equipment != null)
            {
                // Add to mech in the specified location
                AddEquipmentToLocation(mech, equipment, location);
            }
        }
    }
    
    private static void CalculateStructureValues(Mech mech)
    {
        // Standard internal structure values based on tonnage
        mech.Structure.Head = 3;
        
        if (mech.Mass <= 55)
        {
            // Light/Medium Mechs
            mech.Structure.CenterTorso = mech.Mass / 10 + 11;
            mech.Structure.LeftTorso = mech.Structure.RightTorso = mech.Mass / 10 + 7;
            mech.Structure.LeftArm = mech.Structure.RightArm = mech.Mass / 10 + 3;
            mech.Structure.LeftLeg = mech.Structure.RightLeg = mech.Mass / 10 + 5;
        }
        else
        {
            // Heavy/Assault Mechs
            mech.Structure.CenterTorso = mech.Mass / 5 + 6;
            mech.Structure.LeftTorso = mech.Structure.RightTorso = mech.Mass / 5 + 4;
            mech.Structure.LeftArm = mech.Structure.RightArm = mech.Mass / 10 + 5;
            mech.Structure.LeftLeg = mech.Structure.RightLeg = mech.Mass / 5 + 2;
        }
    }
    
    private static bool IsSectionHeader(string line)
    {
        return line.EndsWith(":") && !line.Contains(" ");
    }
    
    private static bool TryParseLocation(string locationName, out Location location)
    {
        location = Location.Head; // Default initialization
        
        switch (locationName.ToLower())
        {
            case "head":
                location = Location.Head;
                return true;
            case "center torso":
                location = Location.CenterTorso;
                return true;
            case "left torso":
                location = Location.LeftTorso;
                return true;
            case "right torso":
                location = Location.RightTorso;
                return true;
            case "left arm":
                location = Location.LeftArm;
                return true;
            case "right arm":
                location = Location.RightArm;
                return true;
            case "left leg":
                location = Location.LeftLeg;
                return true;
            case "right leg":
                location = Location.RightLeg;
                return true;
            default:
                return false;
        }
    }
    
    private static MechEquipment CreateWeapon(string weaponName)
    {
        // Determine critical slots and tonnage based on weapon type
        int slots = 1;
        double tonnage = 1.0;
        int heat = 0;
        
        // These are approximate values for common weapons
        if (weaponName.Contains("PPC"))
        {
            slots = 3;
            tonnage = 7.0;
            heat = 10;
        }
        else if (weaponName.Contains("Autocannon/5"))
        {
            slots = 4;
            tonnage = 8.0;
            heat = 1;
        }
        else if (weaponName.Contains("Medium Laser"))
        {
            slots = 1;
            tonnage = 1.0;
            heat = 3;
        }
        else if (weaponName.Contains("Large Laser"))
        {
            slots = 2;
            tonnage = 5.0;
            heat = 8;
        }
        else if (weaponName.Contains("Small Laser"))
        {
            slots = 1;
            tonnage = 0.5;
            heat = 1;
        }
        else if (weaponName.Contains("LRM"))
        {
            // Extract the number from e.g., "LRM 15"
            var match = Regex.Match(weaponName, @"\d+");
            int size = match.Success ? int.Parse(match.Value) : 5;
            slots = size <= 5 ? 1 : (size <= 10 ? 2 : (size <= 15 ? 3 : (size <= 20 ? 5 : 6)));
            tonnage = size / 5.0;
            heat = size / 5;
        }
        else if (weaponName.Contains("SRM"))
        {
            // Extract the number from e.g., "SRM 6"
            var match = Regex.Match(weaponName, @"\d+");
            int size = match.Success ? int.Parse(match.Value) : 2;
            slots = size <= 2 ? 1 : (size <= 4 ? 2 : 3);
            tonnage = size / 2.0;
            heat = size / 2;
        }
        
        // Create the weapon
        return new GenericWeapon(weaponName, slots, (decimal)tonnage, heat);
    }
    
    private static MechEquipment CreateEquipment(string equipmentName)
    {
        // For ammo and other equipment
        if (equipmentName.Contains("Ammo"))
        {
            return new Ammunition(
                equipmentName,
                1,
                1.0m,
                0,
                equipmentName.Replace("Ammo", string.Empty).Trim(),
                20);
        }
        else if (equipmentName.Contains("Heat Sink"))
        {
            // Generic representation for heat sinks
            return new GenericWeapon(equipmentName, 1, 1.0m, -3);
        }
        else
        {
            // Generic equipment
            return new GenericWeapon(equipmentName, 1, 1.0m, 0);
        }
    }
    
    private static void AddEquipmentToLocation(Mech mech, MechEquipment equipment, Location location)
    {
        if (!mech.Criticals.TryGetValue(location, out var criticals))
        {
            // Location doesn't exist in the mech
            return;
        }
        
        // Find the first available slots equal to the equipment's critical size
        int consecutiveEmptySlots = 0;
        int startingSlotIndex = -1;
        
        for (int i = 0; i < criticals.Slots.Count; i++)
        {
            if (criticals.Slots[i].Equipment == null)
            {
                // Found an empty slot
                if (consecutiveEmptySlots == 0)
                {
                    startingSlotIndex = i;
                }
                
                consecutiveEmptySlots++;
                
                if (consecutiveEmptySlots >= equipment.CriticalSlots)
                {
                    // We found enough consecutive slots
                    break;
                }
            }
            else
            {
                // Reset counter
                consecutiveEmptySlots = 0;
                startingSlotIndex = -1;
            }
        }
        
        // If we have enough slots, add the equipment
        if (consecutiveEmptySlots >= equipment.CriticalSlots && startingSlotIndex >= 0)
        {
            // Mark the first slot as the "first" slot and put the equipment there
            criticals.Slots[startingSlotIndex].Equipment = equipment;
            criticals.Slots[startingSlotIndex].IsFirst = true;
            
            // Mark the rest of the slots with the same equipment but not as "first"
            for (int i = 1; i < equipment.CriticalSlots; i++)
            {
                if (startingSlotIndex + i < criticals.Slots.Count)
                {
                    criticals.Slots[startingSlotIndex + i].Equipment = equipment;
                    criticals.Slots[startingSlotIndex + i].IsFirst = false;
                }
            }
        }
    }
}
