using MegaMekAbstractions.Common;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Parsers.Exceptions;

namespace MegaMekAbstractions.Parsers.Interfaces;

/// <summary>
/// Interface for parsing MTF (Mech Template Format) files
/// </summary>
public interface IMtfParser
{
    /// <summary>
    /// Parses a complete MTF file into a Mech object
    /// </summary>
    /// <param name="mtfContent">Complete contents of the MTF file</param>
    /// <returns>A Mech object representing the parsed data</returns>
    /// <exception cref="MtfParseException">Thrown when parsing fails</exception>
    Task<Mech> ParseMechDataAsync(string mtfContent);
    
    /// <summary>
    /// Validates if the given content conforms to MTF format
    /// </summary>
    /// <param name="mtfContent">Content to validate</param>
    /// <returns>True if the content represents valid MTF format, false otherwise</returns>
    bool ValidateFormat(string mtfContent);
    
    /// <summary>
    /// Gets the version of the MTF format
    /// </summary>
    /// <param name="mtfContent">MTF content to parse</param>
    /// <returns>Version string of the MTF format</returns>
    /// <exception cref="MtfParseException">Thrown if version cannot be determined</exception>
    string GetMtfVersion(string mtfContent);
    
    /// <summary>
    /// Extracts a specific section from the MTF content
    /// </summary>
    /// <param name="mtfContent">MTF content to parse</param>
    /// <param name="sectionName">Name of the section to extract</param>
    /// <returns>Content of the requested section</returns>
    /// <exception cref="MtfParseException">Thrown if section cannot be found or parsed</exception>
    string GetSection(string mtfContent, string sectionName);
    
    /// <summary>
    /// Gets the names of all sections present in the MTF content
    /// </summary>
    /// <param name="mtfContent">MTF content to analyze</param>
    /// <returns>Array of section names found in the content</returns>
    string[] GetSectionNames(string mtfContent);
}
