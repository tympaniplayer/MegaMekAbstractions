# MegaMekDb

This library provides functionality to import and manage MegaMek MTF files in a PostgreSQL database using Entity Framework Core.

## Features

- Import MTF files into a database
- Update existing MTF records when files change
- Track file origin and modification dates
- Store complete Mech data including armor, structure, and equipment

## Database Structure

The database consists of the following tables:

- **Mechs**: Main table storing basic Mech information
- **Quirks**: Quirks associated with each Mech
- **ArmorValues**: Armor values for each location on a Mech
- **StructureValues**: Structure values for each location on a Mech
- **Equipment**: Weapons and equipment installed on a Mech

## Services

### MtfImportService

Handles importing individual MTF files into the database:

```csharp
// Import a single MTF file
var mechId = await importService.ImportMtfFileAsync(filePath, fileContent);
```

### MtfBulkImportService

Handles importing multiple MTF files from a directory:

```csharp
// Import all MTF files from a directory
var result = await bulkImportService.ImportMtfFilesFromDirectoryAsync(directoryPath, recursive);
Console.WriteLine($"Total: {result.Total}, Added: {result.Added}, Updated: {result.Updated}, Skipped: {result.Skipped}");
```

## Entity Framework Integration

The library uses Entity Framework Core with the PostgreSQL provider. To configure your database connection, use the `MechDbContext` class:

```csharp
services.AddDbContext<MechDbContext>(options =>
{
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});
