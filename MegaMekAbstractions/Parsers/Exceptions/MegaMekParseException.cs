namespace MegaMekAbstractions.Parsers.Exceptions;

/// <summary>
/// Base exception class for MegaMek parsing operations
/// </summary>
public abstract class MegaMekParseException : Exception
{
    /// <summary>
    /// Gets the name of the file being parsed
    /// </summary>
    public string? FileName { get; }

    /// <summary>
    /// Creates a new instance of MegaMekParseException
    /// </summary>
    /// <param name="message">The error message</param>
    protected MegaMekParseException(string message) : base(message)
    {
    }

    /// <summary>
    /// Creates a new instance of MegaMekParseException
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="fileName">Name of the file being parsed</param>
    protected MegaMekParseException(string message, string fileName) : base(message)
    {
        FileName = fileName;
    }

    /// <summary>
    /// Creates a new instance of MegaMekParseException
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="fileName">Name of the file being parsed</param>
    /// <param name="innerException">The inner exception that caused this error</param>
    protected MegaMekParseException(string message, string fileName, Exception innerException) 
        : base(message, innerException)
    {
        FileName = fileName;
    }
}
