using MegaMekAbstractions.Parsers.Constants;
using MegaMekAbstractions.Parsers.Interfaces;
using MegaMekParser.Mtf.Parsers;

namespace MegaMekParser.Mtf;

/// <summary>
/// Factory class for creating MTF file parsers
/// </summary>
public class ParserFactory : IMechParserFactory
{
    /// <summary>
    /// Creates a parser appropriate for the given file path
    /// </summary>
    /// <param name="filePath">Path to the file that needs to be parsed</param>
    /// <returns>An appropriate parser for the file, or null if no suitable parser is found</returns>
    public IMtfParser? CreateParser(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return null;

        var extension = Path.GetExtension(filePath).ToLowerInvariant();
        return extension == MtfConstants.Extensions.Mtf ? CreateParserForFormat(MechFileFormat.Mtf) : null;
    }

    /// <summary>
    /// Creates a parser for a specific file format
    /// </summary>
    /// <param name="format">Format identifier</param>
    /// <returns>A parser for the specified format, or null if format is not supported</returns>
    public IMtfParser? CreateParserForFormat(MechFileFormat format)
    {
        return format switch
        {
            MechFileFormat.Mtf => new MtfParser(),
            _ => null
        };
    }

    /// <summary>
    /// Gets all supported file formats
    /// </summary>
    /// <returns>Array of supported formats</returns>
    public MechFileFormat[] GetSupportedFormats()
    {
        return new[] { MechFileFormat.Mtf };
    }

    /// <summary>
    /// Gets file extensions associated with a format
    /// </summary>
    /// <param name="format">Format identifier</param>
    /// <returns>Array of file extensions for the format</returns>
    public string[] GetFormatExtensions(MechFileFormat format)
    {
        return format switch
        {
            MechFileFormat.Mtf => new[] { MtfConstants.Extensions.Mtf },
            _ => Array.Empty<string>()
        };
    }
}
