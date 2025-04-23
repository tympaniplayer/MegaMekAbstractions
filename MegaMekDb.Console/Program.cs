using MegaMekAbstractions.Parsers.Interfaces;
using MegaMekDb.Data;
using MegaMekDb.Services;
using MegaMekParser.Mtf.Parsers;
using MegaMekParser.Mtf.Readers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddCommandLine(args);

// Configure services
builder.Services.AddDbContext<MechDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException(
            "Connection string 'DefaultConnection' not found. " +
            "Please add it to user secrets with: dotnet user-secrets set \"ConnectionStrings:DefaultConnection\" \"your-connection-string\"");
    }
    options.UseNpgsql(connectionString);
});

// Add MegaMek services
builder.Services.AddSingleton<IMtfParser, MtfParser>();
builder.Services.AddSingleton<IMechFileReader, MtfFileReader>(serviceProvider => 
    new MtfFileReader(serviceProvider.GetRequiredService<IMtfParser>()));
builder.Services.AddScoped<MtfImportService>();
builder.Services.AddScoped<MtfBulkImportService>(provider => 
    new MtfBulkImportService(
        provider.GetRequiredService<MechDbContext>(),
        provider.GetRequiredService<MtfImportService>(),
        provider.GetRequiredService<IMechFileReader>(),
        provider.GetRequiredService<IMtfParser>(),
        provider.GetRequiredService<ILogger<MtfBulkImportService>>()
    ));

// Build the host
using var host = builder.Build();

// Get the services
var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    // Create database
    var dbContext = services.GetRequiredService<MechDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
    
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Database initialized successfully");
    
    // Parse command line arguments
    var command = args.Length > 0 ? args[0].ToLower() : "help";
    
    switch (command)
    {
        case "import":
            if (args.Length < 2)
            {
                logger.LogError("Import directory not specified. Usage: MegaMekDb.Console import <directory>");
                return 1;
            }
            
            var importService = services.GetRequiredService<MtfBulkImportService>();
            var importDirectory = args[1];
            var recursive = args.Length > 2 && args[2].ToLower() == "true";
            
            logger.LogInformation("Importing MTF files from {Directory} (Recursive: {Recursive})", 
                importDirectory, recursive);
                
            try
            {
                var result = await importService.ImportMtfFilesFromDirectoryAsync(importDirectory, recursive);
                logger.LogInformation("Import completed: Total={Total}, Added={Added}, Updated={Updated}, Skipped={Skipped}",
                    result.Total, result.Added, result.Updated, result.Skipped);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error importing MTF files");
                return 1;
            }
            break;
            
        case "help":
        default:
            Console.WriteLine("MegaMekDb.Console - Tool for managing the MegaMek database");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine("  import <directory> [recursive]  Import MTF files from the specified directory");
            Console.WriteLine("  help                            Display this help message");
            break;
    }
    
    return 0;
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during startup");
    return 1;
}
