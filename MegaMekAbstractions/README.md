# MegaMekAbstractions

MegaMekAbstractions is a .NET library that provides abstractions for BattleTech MegaMek data structures. This package contains the core domain models for representing BattleTech mechs and their components.

## Features

- Strong typing for BattleTech concepts (mechs, equipment, etc.)
- Domain models for mech components (armor, structure, heat sinks, etc.)
- Abstractions for various tech levels and equipment
- Support for parsing different file formats

## Installation

```
dotnet add package MegaMekAbstractions
```

## Usage

```csharp
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Common;

// Create a mech
var mech = new Mech
{
    Chassis = "Marauder",
    Model = "MAD-3R",
    Mass = 75,
    TechBase = TechBase.InnerSphere,
    Configuration = Configuration.Biped,
    // Add more properties as needed
};

// Access properties
Console.WriteLine($"Mech: {mech.Chassis} {mech.Model}");
Console.WriteLine($"Mass: {mech.Mass} tons");
```

## License

MIT
