namespace MegaMekAbstractions.Parsers.Exceptions;

/// <summary>
/// Exception thrown when parsing MTF (Mech Template Format) files fails
/// </summary>
public class MtfParseException : MegaMekParseException
{
    /// <summary>
    /// Gets the line number where the parsing error occurred
    /// </summary>
    public int LineNumber { get; }
    
    /// <summary>
    /// Gets the section of the MTF file where the error occurred
    /// </summary>
    public string Section { get; }
    
    /// <summary>
    /// Gets the version of the MTF format being parsed
    /// </summary>
    public string? FormatVersion { get; }

    /// <summary>
    /// Creates a new instance of MtfParseException
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="fileName">Name of the file being parsed</param>
    /// <param name="lineNumber">Line number where the error occurred</param>
    /// <param name="section">Section where the error occurred</param>
    /// <param name="formatVersion">Version of the MTF format</param>
    public MtfParseException(string message, string fileName, int lineNumber, string section, string? formatVersion = null) 
        : base($"Error parsing MTF file '{fileName}' at line {lineNumber} in section '{section}': {message}", fileName)
    {
        LineNumber = lineNumber;
        Section = section;
        FormatVersion = formatVersion;
    }
    
    /// <summary>
    /// Creates a new instance of MtfParseException
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="fileName">Name of the file being parsed</param>
    /// <param name="lineNumber">Line number where the error occurred</param>
    /// <param name="section">Section where the error occurred</param>
    /// <param name="innerException">The inner exception that caused this error</param>
    /// <param name="formatVersion">Version of the MTF format</param>
    public MtfParseException(string message, string fileName, int lineNumber, string section, Exception innerException, string? formatVersion = null) 
        : base($"Error parsing MTF file '{fileName}' at line {lineNumber} in section '{section}': {message}", fileName, innerException)
    {
        LineNumber = lineNumber;
        Section = section;
        FormatVersion = formatVersion;
    }
}
