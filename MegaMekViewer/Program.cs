using MegaMekParser.Mtf.Parsers;
using MegaMekAbstractions.Parsers.Interfaces;
using MegaMekViewer;

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

    // Render the mech record sheet
    var renderer = new RecordSheetRenderer();
    renderer.RenderMech(mech);
}
catch (Exception ex)
{
    Console.WriteLine($"Error parsing file: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner error: {ex.InnerException.Message}");
    }
}
