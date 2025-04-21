using MegaMekParser.Mtf.Parsers;
using MegaMekAbstractions.Parsers.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

if (args.Length == 0)
{
    Console.WriteLine("Please provide a path to an MTF file.");
    return;
}

var filePath = args[0];
if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found: {filePath}");
    return;
}

try
{
    var content = await File.ReadAllTextAsync(filePath);
    IMtfParser parser = new MtfParser();
    var mech = await parser.ParseMechDataAsync(content);

    // Pretty print the mech details as JSON
    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter() }
    };
    
    var json = JsonSerializer.Serialize(mech, options);
    Console.WriteLine(json);
}
catch (Exception ex)
{
    Console.WriteLine($"Error parsing file: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner error: {ex.InnerException.Message}");
    }
}
