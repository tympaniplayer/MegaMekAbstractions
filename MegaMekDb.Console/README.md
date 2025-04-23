# MegaMekDb.Console

A command-line tool for importing MegaMek MTF files into a PostgreSQL database.

## Prerequisites

- .NET 9.0 SDK or later
- Access to a PostgreSQL database (NeonDB is recommended)

## Setup

1. Clone the repository
2. Navigate to the MegaMekDb.Console directory
3. Initialize user secrets (if not already done):

   ```shell
   dotnet user-secrets init
   ```

4. Set your database connection string in user secrets:

   ```shell
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=db.neon.tech;Database=megamekdb;Username=your_username;Password=your_password;Ssl Mode=Require;Trust Server Certificate=true"
   ```

## Usage

### Importing MTF Files

To import MTF files from a directory:

```shell
dotnet run import /path/to/mtf/files [recursive]
```

Where:

- `/path/to/mtf/files`: Path to the directory containing MTF files
- `recursive`: Optional boolean parameter (true/false) to search subdirectories. Defaults to false.

Example:

```shell
dotnet run import /Applications/mekhq-0.49.19.1/data/mechfiles/mechs true
```

This will:

1. Connect to the database using your stored connection string
2. Create any required database tables (if they don't exist)
3. Import all .mtf files found in the specified directory
4. Report the number of files added, updated, and skipped

### Help

To display help information:

```shell
dotnet run help
```

## Managing User Secrets

To list all stored secrets:

```shell
dotnet user-secrets list
```

To remove a stored secret:

```shell
dotnet user-secrets remove "ConnectionStrings:DefaultConnection"
```

To clear all stored secrets:

```shell
dotnet user-secrets clear
```

User secrets are stored in the following location:

- Windows: `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`
- macOS/Linux: `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`
