# Mega Mek Abstractions

A .NET library providing abstractions and domain models for MegaMek file formats. This library focuses on defining the domain model and interfaces needed to work with MegaMek data, particularly the MTF (Mech Template Format) files.

For more information about MegaMek, visit [the official MegaMek website](https://megamek.org/).

## Features

- Complete domain model for BattleMechs
- MTF file parsing abstractions
- Support for equipment, weapons, and critical slots
- Flexible architecture for different file format implementations

## Installation

Install via NuGet:

```bash
dotnet add package MegaMekAbstractions
```

## Usage

The library provides interfaces and models for working with MegaMek data:

```csharp
// Read a mech file
IMechFileReader reader = // your implementation
IMtfParser parser = // your implementation

var content = await reader.ReadFileContentAsync("mech.mtf");
var mech = await parser.ParseMechDataAsync(content);

// Access mech properties
Console.WriteLine($"Mech: {mech.Chassis} {mech.Model}");
Console.WriteLine($"Mass: {mech.Mass} tons");
Console.WriteLine($"Tech Base: {mech.TechBase}");
```

## Tutorial

This section shows how to parse an official MTF file from the [MegaMek repository](https://github.com/MegaMek/megamek) and view it or import it with the tools included in this solution.

1. Download the sample [Archer ARC-2R](https://raw.githubusercontent.com/MegaMek/megamek/master/megamek/data/mekfiles/meks/3039u/Archer%20ARC-2R.mtf) file from the MegaMek project.

### Viewing the record sheet

Use `MegaMekViewer` to render the MTF file with `RecordSheetRenderer`:

```bash
# from the repository root
dotnet run --project MegaMekViewer path/to/Archer\ ARC-2R.mtf
```

### Importing with MegaMekDb.Console

The database console tool can import one or more MTF files:

```bash
# from the repository root
dotnet run --project MegaMekDb.Console import path/to/mtf/files [recursive]
```

The linked MegaMek repository above is the authoritative source for all data files.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

This library provides .NET abstractions for working with [MegaMek](https://megamek.org/) file formats and data structures. MegaMek is a free, online adaptation of Classic BattleTech that lets you play both against the computer and against other people over the internet.
