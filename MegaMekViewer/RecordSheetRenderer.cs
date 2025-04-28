using System.Text;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Mechs.Equipment;

namespace MegaMekViewer;

public class RecordSheetRenderer
{
    private const int DisplayWidth = 83;

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
        Console.WriteLine(new string('=', DisplayWidth));
        Console.WriteLine();
        RenderMainSection(mech);

        // Weapons and equipment
        Console.WriteLine();
        Console.WriteLine(new string('=', DisplayWidth));
        Console.WriteLine();
        RenderWeaponsAndEquipment(mech);

        // Critical hit table
        Console.WriteLine();
        Console.WriteLine(new string('=', DisplayWidth));
        Console.WriteLine();
        RenderCriticalHitTable(mech);
    }

    private void RenderHeader(Mech mech)
    {
        string title = $"BATTLETECH MECH RECORD SHEET";
        string subTitle = $"{mech.Chassis.ToUpper()} {mech.Model.ToUpper()}";
        Console.WriteLine(title.PadLeft((DisplayWidth + title.Length) / 2).PadRight(DisplayWidth));
        Console.WriteLine(subTitle.PadLeft((DisplayWidth + subTitle.Length) / 2).PadRight(DisplayWidth));
        Console.WriteLine(new string('-', DisplayWidth));

        // Basic info row - using two-column layout
        var chassisInfo = $"Type: {mech.Chassis} {mech.Model}";
        Console.WriteLine(chassisInfo +
                         $"Mass: {mech.Mass} tons".PadLeft(DisplayWidth - chassisInfo.Length));

        var techBaseInfo = $"Tech Base: {mech.TechBase}";
        Console.WriteLine(techBaseInfo +
                         $"Era: {mech.Era}".PadLeft(DisplayWidth - techBaseInfo.Length));

        var rulesLevelInfo = $"Rules Level: {mech.RulesLevel}";
        Console.WriteLine(rulesLevelInfo +
                         $"Source: {mech.Source}".PadLeft(DisplayWidth - rulesLevelInfo.Length));

        var roleInfo = $"Role: {mech.GroundRole}";
        Console.WriteLine(roleInfo +
                         $"Config: {mech.Configuration}".PadLeft(DisplayWidth - roleInfo.Length));

        // Quirks
        if (mech.Quirks.Count > 0)
        {
            var quirkList = new StringBuilder();
            foreach (var quirk in mech.Quirks)
            {
                if (quirkList.Length + quirk.ToString().Length > DisplayWidth)
                {
                    Console.WriteLine(quirkList.ToString());
                    quirkList.Clear();
                }
                else if (quirk != mech.Quirks.Last())
                {
                    quirkList.Append(quirk + ", ");
                }
                else
                {
                    quirkList.Append(quirk);
                }
            }
            Console.WriteLine($"Quirks:");
            Console.WriteLine(quirkList);
        }
    }

    private void RenderMainSection(Mech mech)
    {
        // Movement and Heat section titles
        Console.WriteLine("MOVEMENT DATA" + "HEAT DATA".PadLeft(DisplayWidth - 13));
        Console.WriteLine(new string('-', DisplayWidth));

        var engineData = $"Engine: {mech.Engine.Rating} {mech.Engine.Type}";
        // Movement and Heat data
        Console.WriteLine($"{engineData}" +
                        $"Heat Sinks: {mech.HeatSinks.Count} {mech.HeatSinks.Type}".PadLeft(DisplayWidth - engineData.Length));

        Console.WriteLine($"Walking: {mech.Engine.WalkingMP}");

        Console.WriteLine($"Running: {mech.Engine.RunningMP}");

        Console.WriteLine($"Jumping: {mech.Engine.JumpingMP}");

        // Cockpit and Gyro
        Console.WriteLine(new string('-', DisplayWidth));
        var cockpitInfo = $"Cockpit: {mech.Cockpit}";
        Console.WriteLine($"{cockpitInfo}" +
                        $"Gyro: {mech.Gyro}".PadLeft(DisplayWidth - cockpitInfo.Length));

        // Armor and structure
        Console.WriteLine(new string('-', DisplayWidth));
        Console.WriteLine("ARMOR & STRUCTURE".PadLeft((DisplayWidth + 16) / 2).PadRight(DisplayWidth));
        Console.WriteLine(new string('-', DisplayWidth));

        // Armor diagram and values
        RenderArmorDiagram(mech);
    }

    private void RenderArmorDiagram(Mech mech)
    {
        // Basic mech diagram with armor/structure values
        var structureValues = mech.Structure;
        var armorValues = mech.Armor;

        // Basic mech diagram alignment with fixed alignments
        string centerTitle = "BATTLEMECH DIAGRAM";
        Console.WriteLine(centerTitle.PadLeft((DisplayWidth + 18) / 2).PadRight(DisplayWidth));
        Console.WriteLine();

        // HEAD section
        string head = "HEAD";
        int headPosition = (DisplayWidth + head.Length) / 2;
        Console.WriteLine(head.PadLeft(headPosition).PadRight(DisplayWidth));

        string headArmor = $"A: [{armorValues.Head}]";
        int headArmorPosition = (DisplayWidth + headArmor.Length) / 2;
        Console.WriteLine(headArmor.PadLeft(headPosition).PadRight(DisplayWidth));

        string headStruct = $"S: ({structureValues.Head})";
        Console.WriteLine(headStruct.PadLeft(headPosition).PadRight(DisplayWidth));
        Console.WriteLine();

        // Left Torso, Center Torso, Right Torso row
        string leftTorso = "LEFT TORSO";
        string centerTorso = "CENTER TORSO";
        string rightTorso = "RIGHT TORSO";

        // Calculate positions based on DisplayWidth to center the CENTER TORSO
        int centerPosition = DisplayWidth / 2;
        int centerTorsoPosition = centerPosition - (centerTorso.Length / 2) + 1;
        int rightTorsoPosition = centerTorso.Length + DisplayWidth - centerPosition - rightTorso.Length - 6;

        // Build the string with proper positioning
        string torsoRow = "";
        torsoRow += leftTorso;
        torsoRow += centerTorso.PadLeft(centerTorsoPosition);
        torsoRow += rightTorso.PadLeft(rightTorsoPosition);
        Console.WriteLine(torsoRow);

        // Armor values with proper alignment
        string leftTorsoArmor = $"A: [{armorValues.LeftTorso}]";
        string centerTorsoArmor = $"A: [{armorValues.CenterTorso}]";
        string rightTorsoArmor = $"A: [{armorValues.RightTorso}]";

        string armorRow = "";
        armorRow += leftTorsoArmor;
        armorRow += centerTorsoArmor.PadLeft(centerTorsoPosition - 2);
        armorRow += rightTorsoArmor.PadLeft(rightTorsoPosition + 1);
        Console.WriteLine(armorRow);

        // Structure values with proper alignment
        string leftTorsoStruct = $"S: ({structureValues.LeftTorso})";
        string centerTorsoStruct = $"S: ({structureValues.CenterTorso})";
        string rightTorsoStruct = $"S: ({structureValues.RightTorso})";

        string structRow = "";
        structRow += leftTorsoStruct;
        structRow += centerTorsoStruct.PadLeft(centerTorsoPosition - 2);
        structRow += rightTorsoStruct.PadLeft(rightTorsoPosition + 1);
        Console.WriteLine(structRow);

        // Rear armor values with proper alignment
        string leftTorsoRear = $"Rear: [{armorValues.LeftTorsoRear}]";
        string centerTorsoRear = $"Rear: [{armorValues.CenterTorsoRear}]";
        string rightTorsoRear = $"Rear: [{armorValues.RightTorsoRear}]";

        string rearRow = "";
        rearRow += leftTorsoRear;
        rearRow += centerTorsoRear.PadLeft(centerTorsoPosition - 1);
        rearRow += rightTorsoRear.PadLeft(rightTorsoPosition);
        Console.WriteLine(rearRow);

        Console.WriteLine();

        // Left Arm, Right Arm row
        string leftArm = "LEFT ARM";
        string rightArm = "RIGHT ARM";
        int rightArmPosition = DisplayWidth - rightArm.Length - 1;
        Console.WriteLine($"{leftArm}{rightArm.PadLeft(rightArmPosition)}");

        string leftArmArmor = $"A: [{armorValues.LeftArm}]";
        string rightArmArmor = $"A: [{armorValues.RightArm}]".PadLeft(rightArmPosition - 1);
        Console.WriteLine($"{leftArmArmor}{rightArmArmor}");

        string leftArmStruct = $"S: ({structureValues.LeftArm})";
        string rightArmStruct = $"S: ({structureValues.RightArm})".PadLeft(rightArmPosition - 1);
        Console.WriteLine($"{leftArmStruct}{rightArmStruct}");



        Console.WriteLine();

        // Left Leg, Right Leg row
        string leftLeg = "LEFT LEG";
        string rightLeg = "RIGHT LEG";
        int rightLegPosition = DisplayWidth - rightLeg.Length - 1;
        Console.WriteLine($"{leftLeg}{rightLeg.PadLeft(rightLegPosition)}");

        string leftLegArmor = $"A: [{armorValues.LeftLeg,2}]";
        string rightLegArmor = $"A: [{armorValues.RightLeg,2}]".PadLeft(rightLegPosition - 1);
        Console.WriteLine($"{leftLegArmor}{rightLegArmor}");

        string leftLegStruct = $"S: ({structureValues.LeftLeg,2})";
        string rightLegStruct = $"S: ({structureValues.RightLeg,2})".PadLeft(rightLegPosition - 1);
        Console.WriteLine($"{leftLegStruct}{rightLegStruct}");

        Console.WriteLine();

        // Armor and structure type row
        var armorType = $"Armor Type: {armorValues.Type}";
        var structureType = $"Structure Type: {structureValues.Type}";
        var totalArmorPosition = DisplayWidth - armorType.Length - 1;
        var totalStructurePosition = DisplayWidth - structureType.Length - 1;
        var totalArmor = $"Total: {GetTotalArmor(armorValues)}".PadLeft(totalArmorPosition);
        var totalStructure = $"Total: {GetTotalStructure(structureValues)}".PadLeft(totalStructurePosition);
        Console.WriteLine($"Armor Type: {armorValues.Type}{totalArmor}");
        Console.WriteLine($"Structure Type: {structureValues.Type}{totalStructure}");
    }

    private void RenderWeaponsAndEquipment(Mech mech)
    {
        Console.WriteLine("WEAPONS AND EQUIPMENT".PadLeft((DisplayWidth + 20) / 2).PadRight(DisplayWidth));
        Console.WriteLine(new string('-', DisplayWidth));

        // Column headers
        Console.WriteLine($"WEAPON/EQUIPMENT".PadRight(20) + "LOCATION".PadLeft(DisplayWidth - 20));
        Console.WriteLine(new string('-', DisplayWidth));

        // Group equipment by name and location
        var equipmentGroups = mech.Criticals
            .SelectMany(kv => kv.Value.GetEquipment().Select(eq => new { Location = kv.Key, Equipment = eq }))
            .GroupBy(x => x.Equipment.Name)
            .OrderBy(g => g.Key);

        // Skip heat sinks as they'll be displayed as a total in the movement section
        foreach (var group in equipmentGroups.Where(g => !g.Key.Contains("Heat Sink")))
        {
            var locations = group
                .GroupBy(x => x.Location)
                .OrderBy(g => g.Key)
                .Select(g => GetLocationName(g.Key));

            string locationsList = string.Join(", ", locations);

            // List by weapon name first, then location
            Console.WriteLine($"{group.Key.PadRight(20)}{locationsList.PadLeft(DisplayWidth - 20)}");
        }
    }

    private void RenderCriticalHitTable(Mech mech)
    {
        Console.WriteLine("CRITICAL HITS TABLE".PadLeft((DisplayWidth + 18) / 2).PadRight(DisplayWidth));
        Console.WriteLine(new string('-', DisplayWidth));

        // Columns to display side by side (e.g., left arm, right arm, left torso, right torso...)
        Location[] leftLocations = [Location.Head, Location.LeftArm, Location.LeftTorso, Location.LeftLeg];
        Location[] rightLocations = [Location.CenterTorso, Location.RightArm, Location.RightTorso, Location.RightLeg];

        // Maximum slot count needed for display alignment
        int maxSlots = 12;

        // Render each pair of locations side by side
        for (int i = 0; i < leftLocations.Length; i++)
        {
            RenderLocationCriticalSlots(mech, leftLocations[i], rightLocations[i], maxSlots);

            if (i < leftLocations.Length - 1)
            {
                Console.WriteLine(new string('-', DisplayWidth));
            }
        }
    }

    private void RenderLocationCriticalSlots(Mech mech, Location leftLocation, Location rightLocation, int maxSlots)
    {
        var leftCriticals = mech.Criticals.ContainsKey(leftLocation) ? mech.Criticals[leftLocation] : null;
        var rightCriticals = mech.Criticals.ContainsKey(rightLocation) ? mech.Criticals[rightLocation] : null;

        string leftName = GetLocationName(leftLocation);
        string rightName = GetLocationName(rightLocation);

        // Count non-empty slots (excluding heat sinks)
        int leftSlotCount = leftCriticals?.Slots.Count ?? 0;
        int rightSlotCount = rightCriticals?.Slots.Count ?? 0;

        // Don't display locations that have zero slots
        if (leftSlotCount == 0 && rightSlotCount == 0)
            return;

        // Print the location headers
        if (leftSlotCount > 0 && rightSlotCount > 0)
        {
            var rightNamePosition = DisplayWidth - leftName.Length;
            Console.WriteLine($"{leftName}{rightName.PadLeft(rightNamePosition)}{Environment.NewLine}");
        }

        // Maximum number of slots to display
        int maxSlotCount = Math.Max(leftSlotCount, rightSlotCount);
        maxSlotCount = Math.Min(maxSlotCount, maxSlots); // Cap at maxSlots

        // Display all slots, including empty ones
        for (int i = 0; i < maxSlotCount; i++)
        {
            // Get slot contents
            string leftContent = i < leftSlotCount
                ? GetSlotContents(leftCriticals?.Slots[i])
                : "-EMPTY-";

            string rightContent = i < rightSlotCount
                ? GetSlotContents(rightCriticals?.Slots[i])
                : "-EMPTY-";

            string leftText = $"{i + 1}. {leftContent}";
            string rightText = $"{i + 1}. {rightContent}";

            if (i < leftSlotCount && i < rightSlotCount)
            {
                Console.WriteLine($"{leftText}{rightText.PadLeft(DisplayWidth - leftText.Length)}");
            }
            else if (i < leftSlotCount)
            {
                Console.WriteLine($"{leftText}");
            }
            else if (i < rightSlotCount)
            {
                Console.WriteLine($"{rightText.PadLeft(DisplayWidth)}");
            }
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

    private string GetSlotContents(CriticalSlot? slot)
    {
        if (slot == null || slot.Equipment == null)
        {
            return "-Empty-";
        }

        return slot.Equipment.Name;
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
