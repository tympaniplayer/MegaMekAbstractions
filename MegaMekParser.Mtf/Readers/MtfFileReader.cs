using MegaMekAbstractions.Parsers.Constants;
using MegaMekAbstractions.Parsers.Interfaces;

namespace MegaMekParser.Mtf.Readers;

/// <summary>
/// File reader for MTF (Mech Template Format) files
/// </summary>
public class MtfFileReader : IMechFileReader
{
    private readonly IMtfParser _parser;

    /// <summary>
    /// Creates a new instance of MtfFileReader
    /// </summary>
    /// <param name="parser">The MTF parser to use</param>
    public MtfFileReader(IMtfParser parser)
    {
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    /// <inheritdoc />
    public async Task<string> ReadFileContentAsync(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("MTF file not found", filePath);
        }

        // Read all text from the file
        return await File.ReadAllTextAsync(filePath);
    }

    /// <inheritdoc />
    public string[] GetSupportedExtensions()
    {
        // Return the standard MTF extension
        return new[] { MtfConstants.Extensions.Mtf };
    }

    /// <inheritdoc />
    public IMtfParser? GetParser(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            return null;
        }

        // Check if the file has a .mtf extension
        return Path.GetExtension(filePath).Equals(MtfConstants.Extensions.Mtf, StringComparison.OrdinalIgnoreCase) 
            ? _parser 
            : null;
    }
}
