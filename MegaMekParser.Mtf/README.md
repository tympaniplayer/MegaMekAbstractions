# MegaMekParser.Mtf

MegaMekParser.Mtf is a .NET library for parsing BattleTech MegaMek MTF (Mech Template Format) files. This package provides the ability to load and parse MTF files into strongly-typed C# objects.

## Features

- Parse MTF files into domain models
- Support for all standard MTF sections
- Mech quirk parsing
- Weapon and equipment recognition
- Complete mech data representation

## Installation

```
dotnet add package MegaMekParser.Mtf
```

## Usage

```csharp
using MegaMekParser.Mtf.Parsers;
using MegaMekAbstractions.Parsers.Interfaces;
using System.Text.Json;

// Load MTF file content
string mtfContent = await File.ReadAllTextAsync("path/to/mech.mtf");

// Parse the MTF file
IMtfParser parser = new MtfParser();
var mech = await parser.ParseMechDataAsync(mtfContent);

// Access mech properties
Console.WriteLine($"Mech: {mech.Chassis} {mech.Model}");
Console.WriteLine($"Mass: {mech.Mass} tons");
Console.WriteLine($"Tech Base: {mech.TechBase}");

// Get quirks
if (mech.Quirks.Any())
{
    Console.WriteLine("Quirks:");
    foreach (var quirk in mech.Quirks)
    {
        Console.WriteLine($"- {quirk}");
    }
}
```

## Command-line Usage Example

Create a simple viewer app:

```csharp
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
}
```

## License

MIT
