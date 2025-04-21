namespace MegaMekAbstractions.Parsers.Constants;

/// <summary>
/// Constants for MTF (Mech Template Format) file parsing
/// </summary>
public static class MtfConstants
{
    /// <summary>
    /// Standard sections found in MTF files
    /// </summary>
    public static class Sections
    {
        /// <summary>
        /// Version section identifier
        /// </summary>
        public const string Version = "Version:";

        /// <summary>
        /// Mass section identifier
        /// </summary>
        public const string Mass = "Mass:";

        /// <summary>
        /// Chassis section identifier
        /// </summary>
        public const string Chassis = "chassis:";

        /// <summary>
        /// Model section identifier
        /// </summary>
        public const string Model = "model:";

        /// <summary>
        /// Tech Base section identifier
        /// </summary>
        public const string TechBase = "TechBase:";

        /// <summary>
        /// MUL ID section identifier
        /// </summary>
        public const string MulId = "mul id:";

        /// <summary>
        /// Role section identifier
        /// </summary>
        public const string Role = "role:";

        /// <summary>
        /// Quirk section identifier
        /// </summary>
        public const string Quirk = "quirk:";

        /// <summary>
        /// Weapon Quirk section identifier
        /// </summary>
        public const string WeaponQuirk = "weaponquirk:";

        /// <summary>
        /// Configuration section identifier
        /// </summary>
        public const string Config = "Config:";

        /// <summary>
        /// Equipment section identifier
        /// </summary>
        public const string Equipment = "Equipment:";

        /// <summary>
        /// Source section identifier
        /// </summary>
        public const string Source = "Source:";

        /// <summary>
        /// Rules Level section identifier
        /// </summary>
        public const string RulesLevel = "Rules Level:";

        /// <summary>
        /// Engine section identifier
        /// </summary>
        public const string Engine = "Engine:";

        /// <summary>
        /// Internal Structure section identifier
        /// </summary>
        public const string Structure = "Structure:";

        /// <summary>
        /// Heat Sinks section identifier
        /// </summary>
        public const string HeatSinks = "Heat Sinks:";

        /// <summary>
        /// Walk MP section identifier
        /// </summary>
        public const string WalkMP = "Walk MP:";

        /// <summary>
        /// Jump MP section identifier
        /// </summary>
        public const string JumpMP = "Jump MP:";

        /// <summary>
        /// Armor section identifier
        /// </summary>
        public const string Armor = "Armor:";

        /// <summary>
        /// Weapons section identifier
        /// </summary>
        public const string Weapons = "Weapons:";

        /// <summary>
        /// Gyro section identifier
        /// </summary>
        public const string Gyro = "Gyro:";

        /// <summary>
        /// Cockpit section identifier
        /// </summary>
        public const string Cockpit = "Cockpit:";
    }

    /// <summary>
    /// Common values found in MTF files
    /// </summary>
    public static class Values
    {
        /// <summary>
        /// Inner Sphere tech base identifier
        /// </summary>
        public const string InnerSphere = "Inner Sphere";

        /// <summary>
        /// Clan tech base identifier
        /// </summary>
        public const string Clan = "Clan";

        /// <summary>
        /// Mixed (IS Chassis) tech base identifier
        /// </summary>
        public const string MixedIs = "Mixed (IS Chassis)";

        /// <summary>
        /// Mixed (Clan Chassis) tech base identifier
        /// </summary>
        public const string MixedClan = "Mixed (Clan Chassis)";
    }

    /// <summary>
    /// File extensions used by MTF files
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Standard MTF file extension
        /// </summary>
        public const string Mtf = ".mtf";
    }
}
