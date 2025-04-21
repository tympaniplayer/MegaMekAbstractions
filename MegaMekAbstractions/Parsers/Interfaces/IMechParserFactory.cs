using MegaMekAbstractions.Parsers.Constants;

namespace MegaMekAbstractions.Parsers.Interfaces;

/// <summary>
/// Factory interface for creating MegaMek file parsers
/// </summary>
public interface IMechParserFactory
{
    /// <summary>
    /// Creates a parser appropriate for the given file path based on its extension and content
    /// </summary>
    /// <param name="filePath">Path to the file that needs to be parsed</param>
    /// <returns>An appropriate parser for the file, or null if no suitable parser is found</returns>
    IMtfParser? CreateParser(string filePath);
    
    /// <summary>
    /// Creates a parser for a specific file format
    /// </summary>
    /// <param name="format">The format to create a parser for</param>
    /// <returns>A parser for the specified format, or null if format is not supported</returns>
    IMtfParser? CreateParserForFormat(MechFileFormat format);
    
    /// <summary>
    /// Gets all supported file formats
    /// </summary>
    /// <returns>Array of supported formats</returns>
    MechFileFormat[] GetSupportedFormats();
    
    /// <summary>
    /// Gets file extensions associated with a format
    /// </summary>
    /// <param name="format">The format to get extensions for</param>
    /// <returns>Array of file extensions for the format (e.g., [".mtf"])</returns>
    string[] GetFormatExtensions(MechFileFormat format);
}
