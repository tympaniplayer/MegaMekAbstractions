using System.Text;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Mechs.Equipment;

namespace MegaMekViewer;

/// <summary>
/// Renders a Battletech record sheet style representation of a mech in the console
/// </summary>
public class RecordSheetRenderer
{
    private const string HorizontalLine = "─────────────────────────────────────────────────────────────────────────────";
    private const string VerticalLine = "│";
    private const char CornerTopLeft = '┌';
    private const char CornerTopRight = '┐';
    private const char CornerBottomLeft = '└';
    private const char CornerBottomRight = '┘';
    private const char JunctionRight = '├';
    private const char JunctionLeft = '┤';
    private const char JunctionTop = '┬';
    private const char JunctionBottom = '┴';
    private const char Junction = '┼';

    /// <summary>
    /// Renders a mech as a record sheet in the console
    /// </summary>
    /// <param name="mech">The mech to render</param>
    public void RenderMech(Mech mech)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();

        // Header section
        RenderHeader(mech);

        // Main sections using split layout
        Console.WriteLine();
        RenderMainSection(mech);

        // Weapons and equipment
        Console.WriteLine();
        RenderWeaponsAndEquipment(mech);

        // Critical hit table
        Console.WriteLine();
        RenderCriticalHitTable(mech);
    }

    private void RenderHeader(Mech mech)
    {
        Console.WriteLine($"{CornerTopLeft}{HorizontalLine}{CornerTopRight}");
        Console.WriteLine($"{VerticalLine} BATTLETECH MECH RECORD SHEET {mech.Chassis} {mech.Model}".PadRight(HorizontalLine.Length + 2) + VerticalLine);
        Console.WriteLine($"{JunctionRight}{HorizontalLine}{JunctionLeft}");

        // Basic info row
        Console.WriteLine($"{VerticalLine} Type: {mech.Chassis} {mech.Model}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"Mass: {mech.Mass} tons ".PadLeft(HorizontalLine.Length / 2 + 1) + VerticalLine);

        Console.WriteLine($"{VerticalLine} Tech Base: {mech.TechBase}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"Era: {mech.Era} ".PadLeft(HorizontalLine.Length / 2 + 1) + VerticalLine);

        Console.WriteLine($"{VerticalLine} Rules Level: {mech.RulesLevel}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"Source: {mech.Source} ".PadLeft(HorizontalLine.Length / 2 + 1) + VerticalLine);

        Console.WriteLine($"{VerticalLine} Role: {mech.GroundRole}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"Config: {mech.Configuration} ".PadLeft(HorizontalLine.Length / 2 + 1) + VerticalLine);

        // Quirks
        if (mech.Quirks.Count > 0)
        {
            string quirkList = string.Join(", ", mech.Quirks);
            Console.WriteLine($"{VerticalLine} Quirks: {quirkList}".PadRight(HorizontalLine.Length + 2) + VerticalLine);
        }

        Console.WriteLine($"{CornerBottomLeft}{HorizontalLine}{CornerBottomRight}");
    }

    private void RenderMainSection(Mech mech)
    {
        // Top section: Movement and Heat
        Console.WriteLine($"{CornerTopLeft}{HorizontalLine}{CornerTopRight}");

        // Movement data
        Console.WriteLine($"{VerticalLine} MOVEMENT DATA ".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"HEAT DATA ".PadRight(HorizontalLine.Length / 2 + 1) + VerticalLine);
        Console.WriteLine($"{JunctionRight}{new string('─', HorizontalLine.Length / 2)}{Junction}{new string('─', HorizontalLine.Length / 2)}{JunctionLeft}");

        Console.WriteLine($"{VerticalLine} Engine: {mech.Engine.Rating} {mech.Engine.Type}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"Heat Sinks: {mech.HeatSinks.Count} {mech.HeatSinks.Type}".PadRight(HorizontalLine.Length / 2 + 1) + VerticalLine);

        Console.WriteLine($"{VerticalLine} Walking: {mech.Engine.WalkingMP}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"Heat Sink Locations: ".PadRight(HorizontalLine.Length / 2 + 1) + VerticalLine);

        Console.WriteLine($"{VerticalLine} Running: {mech.Engine.RunningMP}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"  {GetHeatSinkLocations(mech)}".PadRight(HorizontalLine.Length / 2 + 1) + VerticalLine);

        Console.WriteLine($"{VerticalLine} Jumping: {mech.Engine.JumpingMP}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $" ".PadRight(HorizontalLine.Length / 2 + 1) + VerticalLine);

        // Cockpit and Gyro
        Console.WriteLine($"{JunctionRight}{new string('─', HorizontalLine.Length / 2)}{Junction}{new string('─', HorizontalLine.Length / 2)}{JunctionLeft}");
        Console.WriteLine($"{VerticalLine} Cockpit: {mech.Cockpit}".PadRight(HorizontalLine.Length / 2 + 1) +
                         $"Gyro: {mech.Gyro}".PadRight(HorizontalLine.Length / 2 + 1) + VerticalLine);

        // Armor and structure
        Console.WriteLine($"{JunctionRight}{new string('─', HorizontalLine.Length / 2)}{Junction}{new string('─', HorizontalLine.Length / 2)}{JunctionLeft}");
        Console.WriteLine($"{VerticalLine} ARMOR & STRUCTURE ".PadRight(HorizontalLine.Length + 2) + VerticalLine);
        Console.WriteLine($"{JunctionRight}{HorizontalLine}{JunctionLeft}");

        // Armor diagram and values
        RenderArmorDiagram(mech);

        Console.WriteLine($"{CornerBottomLeft}{HorizontalLine}{CornerBottomRight}");
    }

    private void RenderArmorDiagram(Mech mech)
    {
        // Basic mech diagram with armor/structure values
        var structureValues = mech.Structure;
        var armorValues = mech.Armor;
        
        // Draw the mech diagram with armor values - ensure proper alignment
        Console.WriteLine($"{VerticalLine}                                 BATTLEMECH DIAGRAM                                {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                                                                   {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                      HEAD                                         {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                   A: [{armorValues.Head,2}]                                       {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                   S: ({structureValues.Head,2})                                       {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                                                                   {VerticalLine}");
        Console.WriteLine($"{VerticalLine}      LEFT ARM                   CENTER TORSO                    RIGHT ARM        {VerticalLine}");
        Console.WriteLine($"{VerticalLine}      A: [{armorValues.LeftArm,2}]                  A: [{armorValues.CenterTorso,2}]                   A: [{armorValues.RightArm,2}]        {VerticalLine}");
        Console.WriteLine($"{VerticalLine}      S: ({structureValues.LeftArm,2})                  S: ({structureValues.CenterTorso,2})                   S: ({structureValues.RightArm,2})        {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                Rear: [{armorValues.CenterTorsoRear,2}]                                   {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                                                                   {VerticalLine}");
        Console.WriteLine($"{VerticalLine}      LEFT TORSO                                          RIGHT TORSO             {VerticalLine}");
        Console.WriteLine($"{VerticalLine}      A: [{armorValues.LeftTorso,2}]                                          A: [{armorValues.RightTorso,2}]             {VerticalLine}");
        Console.WriteLine($"{VerticalLine}      S: ({structureValues.LeftTorso,2})                                          S: ({structureValues.RightTorso,2})             {VerticalLine}");
        Console.WriteLine($"{VerticalLine}      Rear: [{armorValues.LeftTorsoRear,2}]                                      Rear: [{armorValues.RightTorsoRear,2}]             {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                                                                   {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                     LEFT LEG                    RIGHT LEG                         {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                     A: [{armorValues.LeftLeg,2}]                    A: [{armorValues.RightLeg,2}]                         {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                     S: ({structureValues.LeftLeg,2})                    S: ({structureValues.RightLeg,2})                         {VerticalLine}");
        Console.WriteLine($"{VerticalLine}                                                                                   {VerticalLine}");
        Console.WriteLine($"{VerticalLine} Armor Type: {armorValues.Type.ToString().PadRight(25)} Total: {GetTotalArmor(armorValues),-3}             {VerticalLine}");
        Console.WriteLine($"{VerticalLine} Structure Type: {structureValues.Type.ToString().PadRight(22)} Total: {GetTotalStructure(structureValues),-3}             {VerticalLine}");
    }

    private void RenderWeaponsAndEquipment(Mech mech)
    {
        Console.WriteLine($"{CornerTopLeft}{HorizontalLine}{CornerTopRight}");
        Console.WriteLine($"{VerticalLine} WEAPONS AND EQUIPMENT                                                       {VerticalLine}");
        Console.WriteLine($"{JunctionRight}{HorizontalLine}{JunctionLeft}");

        // Column headers
        Console.WriteLine($"{VerticalLine} LOCATION     | WEAPON/EQUIPMENT                                            {VerticalLine}");
        Console.WriteLine($"{JunctionRight}{HorizontalLine}{JunctionLeft}");

        // Group equipment by location using the criticals
        var locationGroups = mech.Criticals
            .SelectMany(kv => kv.Value.GetEquipment().Select(eq => new { Location = kv.Key, Equipment = eq }))
            .GroupBy(x => x.Location)
            .OrderBy(g => g.Key);

        foreach (var group in locationGroups)
        {
            string locationName = GetLocationName(group.Key);

            foreach (var item in group.Select(g => g.Equipment))
            {
                Console.WriteLine($"{VerticalLine} {locationName.PadRight(12)} | {item.Name.PadRight(57)}{VerticalLine}");
            }
        }

        Console.WriteLine($"{CornerBottomLeft}{HorizontalLine}{CornerBottomRight}");
    }

    private void RenderCriticalHitTable(Mech mech)
    {
        Console.WriteLine($"{CornerTopLeft}{HorizontalLine}{CornerTopRight}");
        Console.WriteLine($"{VerticalLine} CRITICAL HIT TABLE                                                          {VerticalLine}");
        Console.WriteLine($"{JunctionRight}{HorizontalLine}{JunctionLeft}");

        // Columns to display side by side (e.g., left arm, right arm, left torso, right torso...)
        Location[] leftLocations = new[] { Location.Head, Location.LeftArm, Location.LeftTorso, Location.LeftLeg };
        Location[] rightLocations = new[] { Location.CenterTorso, Location.RightArm, Location.RightTorso, Location.RightLeg };

        // Header for the left side and right side
        Console.WriteLine($"{VerticalLine} {"LOCATION".PadRight(15)} SLOTS {"".PadRight(15)} | {"LOCATION".PadRight(15)} SLOTS {"".PadRight(15)}{VerticalLine}");
        Console.WriteLine($"{JunctionRight}{HorizontalLine}{JunctionLeft}");

        // Maximum slot count needed for display alignment
        int maxSlots = 12;

        // Render each pair of locations side by side
        for (int i = 0; i < leftLocations.Length; i++)
        {
            RenderLocationCriticalSlots(mech, leftLocations[i], rightLocations[i], maxSlots);

            if (i < leftLocations.Length - 1)
            {
                Console.WriteLine($"{JunctionRight}{HorizontalLine}{JunctionLeft}");
            }
        }

        Console.WriteLine($"{CornerBottomLeft}{HorizontalLine}{CornerBottomRight}");
    }

    private void RenderLocationCriticalSlots(Mech mech, Location leftLocation, Location rightLocation, int maxSlots)
    {
        var leftCriticals = mech.Criticals.ContainsKey(leftLocation) ? mech.Criticals[leftLocation] : null;
        var rightCriticals = mech.Criticals.ContainsKey(rightLocation) ? mech.Criticals[rightLocation] : null;

        string leftName = GetLocationName(leftLocation);
        string rightName = GetLocationName(rightLocation);

        // Get the maximum number of slots from both locations
        int leftSlotCount = leftCriticals?.Slots.Count ?? 0;
        int rightSlotCount = rightCriticals?.Slots.Count ?? 0;
        int maxSlotCount = Math.Max(Math.Max(leftSlotCount, rightSlotCount), maxSlots);

        // Print the location headers
        Console.WriteLine($"{VerticalLine} {leftName.PadRight(15)} {" ".PadRight(15)} | {rightName.PadRight(15)} {" ".PadRight(15)}{VerticalLine}");

        // Print each slot side by side
        for (int i = 0; i < maxSlotCount; i++)
        {
            string leftSlot = i < leftSlotCount && leftCriticals != null ?
                $"{i + 1}. {GetSlotContents(leftCriticals.Slots[i])}" :
                $"{i + 1}. {"".PadRight(15)}";

            string rightSlot = i < rightSlotCount && rightCriticals != null ?
                $"{i + 1}. {GetSlotContents(rightCriticals.Slots[i])}" :
                $"{i + 1}. {"".PadRight(15)}";

            Console.WriteLine($"{VerticalLine} {leftSlot.PadRight(30)} | {rightSlot.PadRight(30)}{VerticalLine}");
        }
    }

    private string GetLocationName(Location location)
    {
        return location switch
        {
            Location.Head => "Head",
            Location.CenterTorso => "Center Torso",
            Location.LeftTorso => "Left Torso",
            Location.RightTorso => "Right Torso",
            Location.LeftArm => "Left Arm",
            Location.RightArm => "Right Arm",
            Location.LeftLeg => "Left Leg",
            Location.RightLeg => "Right Leg",
            Location.CenterTorsoRear => "CT (Rear)",
            Location.LeftTorsoRear => "LT (Rear)",
            Location.RightTorsoRear => "RT (Rear)",
            _ => "Unknown"
        };
    }

    private string GetSlotContents(CriticalSlot slot)
    {
        if (slot == null || slot.Equipment == null)
        {
            return "-Empty-";
        }

        // Break equipment name into smaller parts if needed
        string name = slot.Equipment.Name;
        if (name.Length > 15)
        {
            name = name[..15];
        }

        return name;
    }

    private int GetTotalArmor(ArmorValues armor)
    {
        return armor.Head +
            armor.CenterTorso + armor.CenterTorsoRear +
            armor.LeftTorso + armor.LeftTorsoRear +
            armor.RightTorso + armor.RightTorsoRear +
            armor.LeftArm + armor.RightArm +
            armor.LeftLeg + armor.RightLeg;
    }

    private int GetTotalStructure(StructureValues structure)
    {
        return structure.Head +
            structure.CenterTorso +
            structure.LeftTorso +
            structure.RightTorso +
            structure.LeftArm + structure.RightArm +
            structure.LeftLeg + structure.RightLeg;
    }

    private string GetHeatSinkLocations(Mech mech)
    {
        var heatSinkLocations = mech.Criticals
            .SelectMany(kv => kv.Value.GetEquipment().Where(e => e.Name.Contains("Heat Sink")).Select(eq => kv.Key))
            .GroupBy(loc => loc)
            .OrderBy(g => g.Key)
            .Select(g => $"{GetLocationName(g.Key)}: {g.Count()}");

        return string.Join(", ", heatSinkLocations);
    }
}
