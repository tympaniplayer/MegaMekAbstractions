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
    private static readonly Dictionary<string, Action<string[], Mech>> SectionParsers = new(StringComparer.OrdinalIgnoreCase)
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
        { MtfConstants.Sections.JumpMP, ParseJumpMP },
        { MtfConstants.Sections.Quirk, ParseQuirk },
        { MtfConstants.Sections.WeaponQuirk, ParseWeaponQuirk },
        { MtfConstants.Sections.Myomer, ParseMyomer },
        { MtfConstants.Sections.Manufacturer, ParseManufacturer },
        { MtfConstants.Sections.PrimaryFactory, ParsePrimaryFactory },
        { MtfConstants.Sections.SystemManufacturer, ParseSystemManufacturer },
        { MtfConstants.Sections.Overview, ParseOverview },
        { MtfConstants.Sections.Capabilities, ParseCapabilities },
        { MtfConstants.Sections.Deployment, ParseDeployment },
        { MtfConstants.Sections.History, ParseHistory }
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
            if (line.StartsWith(MtfConstants.Sections.Config, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.Mass, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.Engine, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.TechBase, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.Source, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.Model, StringComparison.OrdinalIgnoreCase))
            {
                mech.Model = GetValue(line, MtfConstants.Sections.Model) ?? "Unknown";
            }
            else if (line.StartsWith(MtfConstants.Sections.Chassis, StringComparison.OrdinalIgnoreCase))
            {
                mech.Chassis = GetValue(line, MtfConstants.Sections.Chassis) ?? "Unknown";
            }
        }
    }

    private static void ParseEngineDetails(string? engineSpec, Engine engine)
    {
        if (engineSpec == null)
        {
            throw new MtfParseException("Engine specification is null", "unknown", 0, "Engine");
        }
        // Format can include additional tokens like "(Clan)" or "Engine(IS)"
        var parts = engineSpec.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 1 && int.TryParse(parts[0], out int rating))
        {
            engine.Rating = rating;
        }

        var engineTypeStr = engineSpec.Substring(parts[0].Length).ToLower();
        if (engineTypeStr.Contains("xl"))
            engine.Type = EngineType.XL;
        else if (engineTypeStr.Contains("light"))
            engine.Type = EngineType.Light;
        else if (engineTypeStr.Contains("compact"))
            engine.Type = EngineType.Compact;
        else if (engineTypeStr.Contains("xxl"))
            engine.Type = EngineType.XXL;
        else if (engineTypeStr.Contains("ice"))
            engine.Type = EngineType.ICE;
        else if (engineTypeStr.Contains("primitive"))
            engine.Type = EngineType.Primitive;
        else if (engineTypeStr.Contains("fuel cell"))
            engine.Type = EngineType.Fuel_Cell;
        else if (engineTypeStr.Contains("fission"))
            engine.Type = EngineType.Fission;
        else
            engine.Type = EngineType.Standard;
    }

    private static Configuration ParseConfiguration(string? config)
    {
        return config?.ToLower() switch
        {
            "biped" => Configuration.Biped,
            "biped omnimech" => Configuration.Biped,
            "tripod omnimech" => Configuration.Tripod,
            "tripod" => Configuration.Tripod,
            "quad" => Configuration.Quad,
            "quad omnimech" => Configuration.Quad,
            "quadvee" => Configuration.QuadVee,
            "quadvee omnimech" => Configuration.QuadVee,
            "lam" => Configuration.LAM,
            _ => throw new MtfParseException($"Unknown configuration: {config}", "unknown", 0, "Configuration")
        };
    }

    private static TechBase ParseTechBaseValue(string? techBase)
    {
        if (string.IsNullOrEmpty(techBase))
        {
            throw new MtfParseException("TechBase value is null or empty", "unknown", 0, "TechBase");
        }
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
            if (line.StartsWith(MtfConstants.Sections.HeatSinks, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.Structure, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.Armor, StringComparison.OrdinalIgnoreCase))
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
                    case "HD Armor":
                    case "Head":
                        mech.Armor.Head = value;
                        break;
                    case "CT Armor":
                    case "Center Torso":
                        mech.Armor.CenterTorso = value;
                        break;
                    case "RTC Armor":
                    case "Center Torso (rear)":
                        mech.Armor.CenterTorsoRear = value;
                        break;
                    case "RT Armor":
                    case "Right Torso":
                        mech.Armor.RightTorso = value;
                        break;
                    case "RTR Armor":
                    case "Right Torso (rear)":
                        mech.Armor.RightTorsoRear = value;
                        break;
                    case "LT Armor":
                    case "Left Torso":
                        mech.Armor.LeftTorso = value;
                        break;
                    case "RTL Armor":
                    case "Left Torso (rear)":
                        mech.Armor.LeftTorsoRear = value;
                        break;
                    case "RA Armor":
                    case "Right Arm":
                        mech.Armor.RightArm = value;
                        break;
                    case "LA Armor":
                    case "Left Arm":
                        mech.Armor.LeftArm = value;
                        break;
                    case "RL Armor":
                    case "Right Leg":
                        mech.Armor.RightLeg = value;
                        break;
                    case "LL Armor":
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
            if (line.StartsWith(MtfConstants.Sections.Gyro, StringComparison.OrdinalIgnoreCase))
            {
                var value = GetValue(line, MtfConstants.Sections.Gyro);
                if (string.IsNullOrEmpty(value))
                {
                    throw new MtfParseException("Gyro value is null or empty", "unknown", 0, "Gyro");
                }
                mech.Gyro = Mech.ToGyro(value);
            }
        }
    }

    private static void ParseCockpit(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Cockpit, StringComparison.OrdinalIgnoreCase))
            {
                var value = GetValue(line, MtfConstants.Sections.Cockpit);
                if (string.IsNullOrEmpty(value))
                {
                    throw new MtfParseException("Cockpit value is null or empty", "unknown", 0, "Cockpit");
                }
                mech.Cockpit = Mech.ToCockpit(value);
            }
        }
    }

    private static void ParseWalkMP(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.WalkMP, StringComparison.OrdinalIgnoreCase))
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
            if (line.StartsWith(MtfConstants.Sections.JumpMP, StringComparison.OrdinalIgnoreCase))
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
        if (string.IsNullOrEmpty(line) || !line.StartsWith(key, StringComparison.OrdinalIgnoreCase))
        {
            throw new MtfParseException($"Invalid line format: {line}", "unknown", 0, key);
        }

        string value = line.Substring(key.Length).Trim();
        if (value.StartsWith(":"))
        {
            value = value[1..].Trim();
        }
        return string.IsNullOrEmpty(value) ? null : value;
    }

    private static void ParseQuirk(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            // Skip if not a quirk line
            if (!line.StartsWith("quirk:", StringComparison.OrdinalIgnoreCase)) continue;

            // Extract just the quirk name part
            var quirkValue = line["quirk:".Length..].Trim().ToLower();
            if (string.IsNullOrEmpty(quirkValue)) continue;

            // Try to convert quirk name to enum
            var enumName = string.Concat(quirkValue.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => char.ToUpper(s[0]) + s[1..].ToLower()));

            if (Enum.TryParse(enumName, true, out Quirk quirk))
            {
                if (!mech.Quirks.Contains(quirk))
                {
                    mech.Quirks.Add(quirk);
                }
            }
            else
            {
                // Handle special cases where file name differs from enum name
                var mappedQuirk = quirkValue switch
                {
                    "command_mech" => (Quirk?)Quirk.CommandMech,
                    "imp_life_support" => (Quirk?)Quirk.ImprovedLifeSupport,
                    "battle_fists_la" => (Quirk?)Quirk.BattleFistsLeftArm,
                    "battle_fists_ra" => (Quirk?)Quirk.BattleFistsRightArm,
                    "imp_target_short" => (Quirk?)Quirk.ImprovedTargetingShort,
                    "imp_target_med" => (Quirk?)Quirk.ImprovedTargetingMedium,
                    "imp_target_long" => (Quirk?)Quirk.ImprovedTargetingLong,
                    "easy_maintain" => (Quirk?)Quirk.EasyToMaintain,
                    "ext_twist" => (Quirk?)Quirk.ExtendedTorsoTwist,
                    "pro_actuator" => (Quirk?)Quirk.ProtectedActuators,
                    "imp_com" => (Quirk?)Quirk.ImprovedCommunications,
                    "imp_sensors" => (Quirk?)Quirk.ImprovedSensors,
                    "bad_rep_is" => (Quirk?)Quirk.InnerSphereBadReputation,
                    "bad_rep_clan" => (Quirk?)Quirk.ClanBadReputation,
                    "difficult_maintain" => (Quirk?)Quirk.DifficultMaintain,
                    "ubiquitous_is" => (Quirk?)Quirk.InnerSphereUbiquitous,
                    "ubiquitous_clan" => (Quirk?)Quirk.ClanUbiquitous,
                    _ => null
                };

                if (mappedQuirk.HasValue && !mech.Quirks.Contains(mappedQuirk.Value))
                {
                    mech.Quirks.Add(mappedQuirk.Value);
                }
            }
        }
    }

    private static void ParseWeaponQuirk(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            // Skip if not a weapon quirk line
            if (!line.StartsWith("weaponquirk:", StringComparison.OrdinalIgnoreCase)) continue;

            // Extract just the weapon quirk part
            var quirkPart = line.Substring("weaponquirk:".Length).Trim();
            var parts = quirkPart.Split(':');
            if (parts.Length < 4) continue;

            var quirkName = parts[0].ToLower();

            // Convert to PascalCase enum name
            var enumName = string.Concat(quirkName.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => char.ToUpper(s[0]) + s[1..].ToLower()));

            if (Enum.TryParse(enumName, true, out Quirk quirk))
            {
                if (!mech.Quirks.Contains(quirk))
                {
                    mech.Quirks.Add(quirk);
                }
            }
        }
    }

    private static void ParseMyomer(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Myomer, StringComparison.OrdinalIgnoreCase))
            {
                mech.Myomer = GetValue(line, MtfConstants.Sections.Myomer) ?? string.Empty;
            }
        }
    }

    private static void ParseManufacturer(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Manufacturer, StringComparison.OrdinalIgnoreCase))
            {
                mech.Manufacturer = GetValue(line, MtfConstants.Sections.Manufacturer) ?? string.Empty;
            }
        }
    }

    private static void ParsePrimaryFactory(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.PrimaryFactory, StringComparison.OrdinalIgnoreCase))
            {
                mech.PrimaryFactory = GetValue(line, MtfConstants.Sections.PrimaryFactory) ?? string.Empty;
            }
        }
    }

    private static void ParseSystemManufacturer(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.SystemManufacturer, StringComparison.OrdinalIgnoreCase))
            {
                var value = GetValue(line, MtfConstants.Sections.SystemManufacturer);
                if (!string.IsNullOrEmpty(value))
                {
                    var parts = value.Split(':', 2);
                    if (parts.Length == 2)
                    {
                        mech.SystemManufacturers[parts[0]] = parts[1];
                    }
                }
            }
        }
    }

    private static void ParseOverview(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Overview, StringComparison.OrdinalIgnoreCase))
            {
                mech.Overview = GetValue(line, MtfConstants.Sections.Overview) ?? string.Empty;
            }
        }
    }

    private static void ParseCapabilities(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Capabilities, StringComparison.OrdinalIgnoreCase))
            {
                mech.Capabilities = GetValue(line, MtfConstants.Sections.Capabilities) ?? string.Empty;
            }
        }
    }

    private static void ParseDeployment(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.Deployment, StringComparison.OrdinalIgnoreCase))
            {
                mech.Deployment = GetValue(line, MtfConstants.Sections.Deployment) ?? string.Empty;
            }
        }
    }

    private static void ParseHistory(string[] lines, Mech mech)
    {
        foreach (var line in lines)
        {
            if (line.StartsWith(MtfConstants.Sections.History, StringComparison.OrdinalIgnoreCase))
            {
                mech.History = GetValue(line, MtfConstants.Sections.History) ?? string.Empty;
            }
        }
    }
}
