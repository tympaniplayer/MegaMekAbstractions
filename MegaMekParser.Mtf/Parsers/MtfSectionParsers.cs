using MegaMekAbstractions.Common;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Parsers.Constants;
using MegaMekAbstractions.Parsers.Exceptions;

namespace MegaMekParser.Mtf.Parsers;

/// <summary>
/// Parsers for different sections of MTF files
/// </summary>
internal static class MtfSectionParsers
{
    private static readonly Dictionary<string, Action<string[], Mech>> SectionParsers = new()
    {
        { MtfConstants.Sections.Config, ParseConfig },
        { MtfConstants.Sections.Mass, ParseMass },
        { MtfConstants.Sections.Engine, ParseEngine },
        { MtfConstants.Sections.TechBase, ParseTechBase },
        { MtfConstants.Sections.Source, ParseSource },
        { MtfConstants.Sections.Model, ParseModel },
        { MtfConstants.Sections.Chassis, ParseModel },  // Both Model and Chassis use the same parser
        { MtfConstants.Sections.HeatSinks, ParseHeatSinks },
        { MtfConstants.Sections.Structure, ParseStructure },
        { MtfConstants.Sections.Armor, ParseArmor },
        { MtfConstants.Sections.Gyro, ParseGyro },
        { MtfConstants.Sections.Cockpit, ParseCockpit },
        { MtfConstants.Sections.WalkMP, ParseWalkMP },
        { MtfConstants.Sections.JumpMP, ParseJumpMP }
    };

    public static void ParseSection(string sectionName, string[] lines, Mech mech)
    {
        if (SectionParsers.TryGetValue(sectionName, out var parser))
        {
            parser(lines, mech);
        }
    }

    private static void ParseConfig(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Config))
            {
                var configValue = GetValue(line, MtfConstants.Sections.Config);
                mech.Configuration = ParseConfiguration(configValue);
                break;
            }
        }
    }

    private static void ParseMass(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Mass))
            {
                var massValue = GetValue(line, MtfConstants.Sections.Mass);
                if (int.TryParse(massValue, out int mass))
                {
                    mech.Mass = mass;
                }
                break;
            }
        }
    }

    private static void ParseEngine(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Engine))
            {
                var engineValue = GetValue(line, MtfConstants.Sections.Engine);
                ParseEngineDetails(engineValue, mech.Engine);
                break;
            }
        }
    }

    private static void ParseTechBase(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.TechBase))
            {
                var techBaseValue = GetValue(line, MtfConstants.Sections.TechBase);
                mech.TechBase = ParseTechBaseValue(techBaseValue);
                break;
            }
        }
    }

    private static void ParseSource(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Source))
            {
                mech.Source = GetValue(line, MtfConstants.Sections.Source) ?? "Unknown";
                break;
            }
        }
    }

    private static void ParseModel(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Model))
            {
                mech.Model = GetValue(line, MtfConstants.Sections.Model) ?? "Unknown";
            }
            else if (line.StartsWith(MtfConstants.Sections.Chassis))
            {
                mech.Chassis = GetValue(line, MtfConstants.Sections.Chassis) ?? "Unknown";
            }
        }
    }

    private static void ParseEngineDetails(string engineSpec, Engine engine)
    {
        // Format: "Rating Type" (e.g., "300 XL" or "200 Standard")
        var parts = engineSpec.Split(' ', 2);
        if (parts.Length >= 1 && int.TryParse(parts[0], out int rating))
        {
            engine.Rating = rating;
        }

        if (parts.Length == 2)
        {
            engine.Type = parts[1].ToLower() switch
            {
                "xl" => EngineType.XL,
                "light" => EngineType.Light,
                "compact" => EngineType.Compact,
                "ice" => EngineType.ICE,
                "xxl" => EngineType.XXL,
                "primitive" => EngineType.Primitive,
                "fuel cell" => EngineType.Fuel_Cell,
                "fission" => EngineType.Fission,
                _ => EngineType.Standard
            };
        }
    }

    private static Configuration ParseConfiguration(string config)
    {
        return config.ToLower() switch
        {
            "biped" => Configuration.Biped,
            "tripod" => Configuration.Tripod,
            "quad" => Configuration.Quad,
            "quadvee" => Configuration.QuadVee,
            "lam" => Configuration.LAM,
            _ => Configuration.Biped
        };
    }

    private static TechBase ParseTechBaseValue(string techBase)
    {
        return techBase.ToLower() switch
        {
            "clan" => TechBase.Clan,
            "mixed (is chassis)" => TechBase.MixedIsChassis,
            "mixed (clan chassis)" => TechBase.MixedClanChassis,
            _ => TechBase.InnerSphere
        };
    }

    private static void ParseHeatSinks(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.HeatSinks))
            {
                var value = GetValue(line, MtfConstants.Sections.HeatSinks);
                if (value?.Contains("Double") == true)
                {
                    mech.HeatSinks.Type = HeatSinkType.Double;
                }
                else if (value?.Contains("Laser") == true)
                {
                    mech.HeatSinks.Type = HeatSinkType.Laser;
                }

                var parts = value?.Split(' ');
                if (parts?.Length > 0 && int.TryParse(parts[0], out int count))
                {
                    mech.HeatSinks.Count = count;
                }
            }
        }
    }

    private static void ParseStructure(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Structure))
            {
                var value = GetValue(line, MtfConstants.Sections.Structure)?.ToLower();
                mech.Structure.Type = value switch
                {
                    "endo steel" => StructureType.Endo_Steel,
                    "composite" => StructureType.Composite,
                    "reinforced" => StructureType.Reinforced,
                    "industrial" => StructureType.Industrial,
                    "primitive" => StructureType.Primitive,
                    "endo composite" => StructureType.Endo_Composite,
                    _ => StructureType.Standard
                };
            }
        }
    }

    private static void ParseArmor(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Armor))
            {
                // Parse armor type
                var value = GetValue(line, MtfConstants.Sections.Armor)?.ToLower();
                mech.Armor.Type = value switch
                {
                    "ferro-fibrous" => ArmorType.Ferro_Fibrous,
                    "light ferro-fibrous" => ArmorType.Light_Ferro_Fibrous,
                    "heavy ferro-fibrous" => ArmorType.Heavy_Ferro_Fibrous,
                    "reactive" => ArmorType.Reactive,
                    "reflective" => ArmorType.Reflective,
                    "hardened" => ArmorType.Hardened,
                    "stealth" => ArmorType.Stealth,
                    "industrial" => ArmorType.Industrial,
                    "commercial" => ArmorType.Commercial,
                    "primitive" => ArmorType.Primitive,
                    "harjel" => ArmorType.HarJel,
                    _ => ArmorType.Standard
                };
            }
            else
            {
                // Parse armor values
                var parts = line.Split(':');
                if (parts.Length != 2) continue;

                var location = parts[0].Trim();
                var valueStr = parts[1].Trim();
                
                if (!int.TryParse(valueStr, out var value)) continue;

                switch (location)
                {
                    case "Head":
                        mech.Armor.Head = value;
                        break;
                    case "Center Torso":
                        mech.Armor.CenterTorso = value;
                        break;
                    case "Center Torso (rear)":
                        mech.Armor.CenterTorsoRear = value;
                        break;
                    case "Right Torso":
                        mech.Armor.RightTorso = value;
                        break;
                    case "Right Torso (rear)":
                        mech.Armor.RightTorsoRear = value;
                        break;
                    case "Left Torso":
                        mech.Armor.LeftTorso = value;
                        break;
                    case "Left Torso (rear)":
                        mech.Armor.LeftTorsoRear = value;
                        break;
                    case "Right Arm":
                        mech.Armor.RightArm = value;
                        break;
                    case "Left Arm":
                        mech.Armor.LeftArm = value;
                        break;
                    case "Right Leg":
                        mech.Armor.RightLeg = value;
                        break;
                    case "Left Leg":
                        mech.Armor.LeftLeg = value;
                        break;
                }
            }
        }
    }

    private static void ParseGyro(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Gyro))
            {
                var value = GetValue(line, MtfConstants.Sections.Gyro);
                mech.Gyro = Mech.ToGyro(value);
            }
        }
    }

    private static void ParseCockpit(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Cockpit))
            {
                var value = GetValue(line, MtfConstants.Sections.Cockpit);
                mech.Cockpit = Mech.ToCockpit(value);
            }
        }
    }

    private static void ParseWalkMP(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.WalkMP))
            {
                var value = GetValue(line, MtfConstants.Sections.WalkMP);
                if (int.TryParse(value, out int mp))
                {
                    mech.Engine.WalkingMP = mp;
                    mech.Engine.RunningMP = (int)(mp * 1.5);
                }
            }
        }
    }

    private static void ParseJumpMP(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.JumpMP))
            {
                var value = GetValue(line, MtfConstants.Sections.JumpMP);
                if (int.TryParse(value, out int mp))
                {
                    mech.Engine.JumpingMP = mp;
                }
            }
        }
    }

    private static string? GetValue(string line, string key)
    {
        if (string.IsNullOrEmpty(line) || !line.StartsWith(key))
        {
            return null;
        }

        string value = line[(key.Length)..].Trim();
        return string.IsNullOrEmpty(value) ? null : value;
    }
}
