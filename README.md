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
dotnet add package Mega-Mek-Abstractions
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
