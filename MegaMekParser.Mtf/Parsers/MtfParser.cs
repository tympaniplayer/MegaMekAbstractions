using System.Text.RegularExpressions;
using MegaMekAbstractions.Common;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Parsers.Constants;
using MegaMekAbstractions.Parsers.Exceptions;
using MegaMekAbstractions.Parsers.Interfaces;

namespace MegaMekParser.Mtf.Parsers;

/// <summary>
/// Parser for MTF (Mech Template Format) files
/// </summary>
public class MtfParser : IMtfParser
{
    // These are the main section headers we want to parse
    private static readonly string[] MainSections = new[]
    {
        "Version",
        "Mass",
        "Chassis",
        "chassis",
        "Model",
        "model",
        "mul id",
        "Tech Base",
        "TechBase",
        "Era",
        "Source",
        "Rules Level",
        "role",
        "quirk",
        "weaponquirk",
        "Config",
        "Walk MP",
        "Jump MP",
        "Engine",
        "Structure",
        "Gyro",
        "Cockpit",
        "Heat Sinks",
        "Armor",
        "Weapons"
    };

    private static readonly Regex SectionHeaderRegex = new(@"^(" + string.Join("|", MainSections.Select(Regex.Escape)) + @"):.*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private const string VersionPattern = @"Version:\s*(.+)|chassis:.*";

    /// <inheritdoc />
    public async Task<Mech> ParseMechDataAsync(string mtfContent)
    {
        if (string.IsNullOrWhiteSpace(mtfContent))
        {
            throw new MtfParseException("MTF content is empty", "unknown", 0, "Content");
        }

        // Split the content into lines
        string[] lines = mtfContent.Split('\n')
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToArray();

        if (lines.Length == 0)
        {
            throw new MtfParseException("MTF content is empty", "unknown", 0, "Content");
        }

        // Initialize mech with required properties
        var mech = new Mech
        {
            Chassis = "Unknown",  // Will be updated during parsing
            Model = "Unknown",    // Will be updated during parsing
            Source = "Unknown",   // Will be updated during parsing
            Engine = new Engine
            {
                Rating = 0,
                Type = EngineType.Standard
            },
            Quirks = new List<Quirk>(),
            Structure = new StructureValues
            {
                Type = StructureType.Standard
            },
            Armor = new ArmorValues
            {
                Type = ArmorType.Standard
            },
            HeatSinks = new HeatSinks
            {
                Type = HeatSinkType.Single
            },
            Gyro = Gyro.Standard,
            Cockpit = Cockpit.Standard
        };

        try
        {
            // Parse version first
            string version = GetMtfVersion(mtfContent);

            // Check for required sections
            if (!ValidateFormat(mtfContent))
            {
                throw new MtfParseException("Version or chassis information not found", "unknown", 0, "Version");
            }

            // Parse each section
            await ParseSectionsAsync(lines, mech);

            return mech;
        }
        catch (MtfParseException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new MtfParseException("Failed to parse MTF content", "unknown", 0, "Unknown", ex);
        }
    }

    /// <inheritdoc />
    public bool ValidateFormat(string mtfContent)
    {
        if (string.IsNullOrWhiteSpace(mtfContent))
            return false;

        try
        {
            // Check for version
            var version = GetMtfVersion(mtfContent);
            if (string.IsNullOrEmpty(version))
                return false;

            // Check for required sections
            string[] lines = mtfContent.Split('\n');
            bool hasConfig = false;
            bool hasMass = false;

            foreach (var line in lines)
            {
                if (line.StartsWith(MtfConstants.Sections.Config, StringComparison.OrdinalIgnoreCase) ||
                    line.StartsWith("Config:", StringComparison.OrdinalIgnoreCase))
                    hasConfig = true;
                else if (line.StartsWith(MtfConstants.Sections.Mass, StringComparison.OrdinalIgnoreCase) ||
                        line.StartsWith("Mass:", StringComparison.OrdinalIgnoreCase))
                    hasMass = true;

                if (hasConfig && hasMass)
                    return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc />
    public string GetMtfVersion(string mtfContent)
    {
        if (string.IsNullOrWhiteSpace(mtfContent))
        {
            throw new MtfParseException("MTF content is empty", "unknown", 0, "Content");
        }

        var match = Regex.Match(mtfContent, VersionPattern, RegexOptions.Multiline);
        if (!match.Success)
        {
            throw new MtfParseException("Version or chassis information not found", "unknown", 0, "Version");
        }

        // If no explicit version, default to "1.0" for MegaMek format
        if (string.IsNullOrWhiteSpace(match.Groups[1].Value))
        {
            return "1.0";
        }

        var version = match.Groups[1].Value.Trim();
        return version.Equals("Invalid", StringComparison.OrdinalIgnoreCase) ? "1.0" : version;
    }

    /// <inheritdoc />
    public string GetSection(string mtfContent, string sectionName)
    {
        var lines = mtfContent.Split('\n')
            .Select(l => l.Trim())
            .ToArray();

        int startIndex = -1;
        int endIndex = lines.Length;

        // Find the start of the section
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(sectionName, StringComparison.OrdinalIgnoreCase))
            {
                startIndex = i;
                break;
            }
        }

        if (startIndex == -1)
        {
            throw new MtfParseException($"Section '{sectionName}' not found", "unknown", 0, "Section");
        }

        // Find the end of the section (start of next section)
        for (int i = startIndex + 1; i < lines.Length; i++)
        {
            if (SectionHeaderRegex.IsMatch(lines[i]))
            {
                endIndex = i;
                break;
            }
        }

        return string.Join(Environment.NewLine, lines.Skip(startIndex).Take(endIndex - startIndex));
    }

    /// <inheritdoc />
    public string[] GetSectionNames(string mtfContent)
    {
        var sections = new List<string>();
        var lines = mtfContent.Split('\n')
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrWhiteSpace(l));

        foreach (var line in lines)
        {
            var match = SectionHeaderRegex.Match(line);
            if (match.Success)
            {
                sections.Add(match.Groups[1].Value.Trim());
            }
        }

        return sections.ToArray();
    }

    private async Task ParseSectionsAsync(string[] lines, Mech mech)
    {
        await Task.Run(() =>
        {
            int currentSectionStart = -1;
            string currentSection = string.Empty;
            var sectionLines = new List<string>();

            for (int i = 0; i <= lines.Length; i++)
            {
                bool isEndOfSection = i == lines.Length;
                if (!isEndOfSection)
                {
                    var line = lines[i].ToLower();
                    if (line.StartsWith("quirk:"))
                    {
                        MtfSectionParsers.ParseSection("quirk:", new[] { lines[i] }, mech);
                        continue;
                    }
                    else if (line.StartsWith("weaponquirk:"))
                    {
                        MtfSectionParsers.ParseSection("weaponquirk:", new[] { lines[i] }, mech);
                        continue;
                    }
                    isEndOfSection = SectionHeaderRegex.IsMatch(lines[i]);
                }

                if (isEndOfSection)
                {
                    // Process previous section if we have one
                    if (currentSectionStart != -1 && !string.IsNullOrEmpty(currentSection))
                    {
                        MtfSectionParsers.ParseSection(currentSection, sectionLines.ToArray(), mech);
                    }

                    if (i < lines.Length)
                    {
                        var match = SectionHeaderRegex.Match(lines[i]);
                        currentSection = match.Groups[1].Value.Trim() + ":";
                        currentSectionStart = i;
                        sectionLines = new List<string> { lines[i] };
                    }
                }
                else if (currentSectionStart != -1)
                {
                    sectionLines.Add(lines[i]);
                }
            }
        });
    }
}
