using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Parsers.Interfaces;

namespace MegaMekAbstractions.Parsers.Interfaces;

/// <summary>
/// Interface for reading MegaMek mech files
/// </summary>
public interface IMechFileReader
{
    /// <summary>
    /// Gets the content of a mech file
    /// </summary>
    /// <param name="filePath">Path to the mech file</param>
    /// <returns>The raw content of the mech file</returns>
    /// <exception cref="FileNotFoundException">Thrown when file is not found</exception>
    /// <exception cref="IOException">Thrown when file cannot be read</exception>
    Task<string> ReadFileContentAsync(string filePath);
    
    /// <summary>
    /// Gets the supported file extensions for this reader
    /// </summary>
    /// <returns>Array of supported file extensions (e.g., ".mtf", ".mul")</returns>
    string[] GetSupportedExtensions();
    
    /// <summary>
    /// Gets the appropriate parser for a given file
    /// </summary>
    /// <param name="filePath">Path to the mech file</param>
    /// <returns>A parser that can handle the file format, or null if no suitable parser is found</returns>
    IMtfParser? GetParser(string filePath);
}
