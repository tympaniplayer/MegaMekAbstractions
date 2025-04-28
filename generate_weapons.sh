#!/bin/bash

# Common functions for name handling
normalize_to_class_name() {
    local name="$1"
    local variant="$2"
    
    # Clean up name and normalize 
    name=$(echo "$name" | tr -d '"()[]{}' | sed 's/[[:space:]]\+/ /g')
    
    # Special case handling for common weapon patterns
    # AutoCannon special case
    if [[ $name == *"Autocannon"* || $name == *"autocannon"* || $name == *"AutoCannon"* ]]; then
        if [[ $name =~ /([0-9]+)$ ]]; then
            echo "AutoCannon${BASH_REMATCH[1]}"
            return
        fi
    fi
    
    # LBX AutoCannon special case
    if [[ $name == *"LB"*"X"*"AC"* || $name == *"LB"*"X"*"AC"* ]]; then
        if [[ $name =~ ([0-9]+) ]]; then
            echo "LBXAutoCannon${BASH_REMATCH[1]}"
            return
        fi
    fi
    
    # Light AC special case
    if [[ $name == *"Light AC"* || $name == *"Light"*"AC"* ]]; then
        if [[ $name =~ /([0-9]+)$ || $name =~ ([0-9]+)$ ]]; then
            echo "LightAutoCannon${BASH_REMATCH[1]}"
            return
        fi
    fi
    
    # Ultra AC special case
    if [[ $name == *"Ultra AC"* || $name == *"Ultra"*"AC"* ]]; then
        if [[ $name =~ /([0-9]+)$ || $name =~ ([0-9]+)$ ]]; then
            echo "UltraAutoCannon${BASH_REMATCH[1]}"
            return
        fi
    fi
    
    # Rotary AC special case
    if [[ $name == *"Rotary AC"* || $name == *"Rotary"*"AC"* ]]; then
        if [[ $name =~ /([0-9]+)$ || $name =~ ([0-9]+)$ ]]; then
            echo "RotaryAutoCannon${BASH_REMATCH[1]}"
            return
        fi
    fi
    
    # ProtoMech AC special case
    if [[ $name == *"ProtoMech AC"* || $name == *"ProtoMech"*"AC"* ]]; then
        if [[ $name =~ /([0-9]+)$ || $name =~ ([0-9]+)$ ]]; then
            echo "ProtoMechAutoCannon${BASH_REMATCH[1]}"
            return
        fi
    fi
    
    # Machine Gun special cases
    if [[ $name == *"Light Machine Gun"* ]]; then
        echo "LightMG"
        return
    fi
    
    if [[ $name == *"Heavy Machine Gun"* ]]; then
        echo "HeavyMG"
        return
    fi
    
    if [[ $name == *"Machine Gun"* ]]; then
        echo "MG"
        return
    fi
    
    # Improved Heavy Laser special cases
    if [[ $name == *"Improved Heavy Small Laser"* ]]; then
        echo "ImprovedHeavySmallLaser"
        return
    fi
    
    if [[ $name == *"Improved Heavy Medium Laser"* ]]; then
        echo "ImprovedHeavyMediumLaser"
        return
    fi
    
    if [[ $name == *"Improved Heavy Large Laser"* ]]; then
        echo "ImprovedHeavyLargeLaser"
        return
    fi
    
    # Gauss weapon special cases
    if [[ $name == *"Improved Heavy Gauss"* ]]; then
        echo "ImprovedHeavyGauss"
        return
    fi
    
    if [[ $name == *"Light Gauss"* ]]; then
        echo "LightGauss"
        return
    fi
    
    if [[ $name == *"Heavy Gauss"* ]]; then
        echo "HeavyGauss"
        return
    fi
    
    if [[ $name == *"Silver Bullet Gauss"* ]]; then
        echo "SilverBulletGauss"
        return
    fi
    
    if [[ $name == *"Magshot Gauss"* ]]; then
        echo "MagshotGauss"
        return
    fi
    
    if [[ $name == *"AP Gauss"* ]]; then
        echo "APGauss"
        return
    fi
    
    if [[ $name == *"Gauss Rifle"* || $name == *"Gauss"* ]]; then
        echo "Gauss"
        return
    fi
    
    # Apply pattern substitutions for complex weapon types
    name=$(echo "$name" | sed -E '
        # Common support equipment
        s/ANTI[- ]*MISSILE[- ]*SYSTEM/AntiMissileSystem/gi;
        s/TARGET[- ]*ACQUISITION[- ]*GEAR[- ]*\(?TAG\)?/TargetAcquisitionGear/gi;
        s/ECM[- ]*SUITE/ECMSuite/gi;
        s/WATCHDOG[- ]*CEWS/WatchdogCEWS/gi;
        s/NARC[- ]*MISSILE[- ]*BEACON/NarcMissileBeacon/gi;
        s/ARROW[- ]*IV/ArrowIV/gi;
        
        # PPCs
        s/SNUB[- ]*NOSE[- ]*PPC/SnubNosePPC/gi;
        s/ER[- ]*PPC/ERPPC/gi;
        s/LIGHT[- ]*PPC/LightPPC/gi;
        s/HEAVY[- ]*PPC/HeavyPPC/gi;
        
        # Lasers
        s/ER[- ]*PULSE[- ]*LARGE[- ]*LASER/ERPulseLargeLaser/gi;
        s/ER[- ]*PULSE[- ]*MEDIUM[- ]*LASER/ERPulseMediumLaser/gi;
        s/ER[- ]*PULSE[- ]*SMALL[- ]*LASER/ERPulseSmallLaser/gi;
        s/ER[- ]*LARGE[- ]*LASER/ERLargeLaser/gi;
        s/ER[- ]*MEDIUM[- ]*LASER/ERMediumLaser/gi;
        s/ER[- ]*SMALL[- ]*LASER/ERSmallLaser/gi;
        s/ER[- ]*MICRO[- ]*LASER/ERMicroLaser/gi;
        s/LARGE[- ]*X[- ]*PULSE[- ]*LASER/LargeXPulseLaser/gi;
        s/MEDIUM[- ]*X[- ]*PULSE[- ]*LASER/MediumXPulseLaser/gi;
        s/SMALL[- ]*X[- ]*PULSE[- ]*LASER/SmallXPulseLaser/gi;
        s/LARGE[- ]*PULSE[- ]*LASER/LargePulseLaser/gi;
        s/MEDIUM[- ]*PULSE[- ]*LASER/MediumPulseLaser/gi;
        s/SMALL[- ]*PULSE[- ]*LASER/SmallPulseLaser/gi;
        s/MICRO[- ]*PULSE[- ]*LASER/MicroPulseLaser/gi;
        s/IMPROVED[- ]*HEAVY[- ]*LARGE[- ]*LASER/ImprovedHeavyLargeLaser/gi;
        s/IMPROVED[- ]*HEAVY[- ]*MEDIUM[- ]*LASER/ImprovedHeavyMediumLaser/gi;
        s/IMPROVED[- ]*HEAVY[- ]*SMALL[- ]*LASER/ImprovedHeavySmallLaser/gi;
        s/HEAVY[- ]*LARGE[- ]*LASER/HeavyLargeLaser/gi;
        s/HEAVY[- ]*MEDIUM[- ]*LASER/HeavyMediumLaser/gi;
        s/HEAVY[- ]*SMALL[- ]*LASER/HeavySmallLaser/gi;
        s/LARGE[- ]*LASER/LargeLaser/gi;
        s/MEDIUM[- ]*LASER/MediumLaser/gi;
        s/SMALL[- ]*LASER/SmallLaser/gi;
        s/MICRO[- ]*LASER/MicroLaser/gi;
        
        # Machine Guns
        s/LIGHT[- ]*MACHINE[- ]*GUN/LightMG/gi;
        s/HEAVY[- ]*MACHINE[- ]*GUN/HeavyMG/gi;
        s/MACHINE[- ]*GUN/MG/gi;
        
        # Missiles
        s/STREAK[- ]*([^- ]+)[- ]*([0-9]+)/Streak\1\2/gi;
        s/ENHANCED[- ]*([^- ]+)[- ]*([0-9]+)/Enhanced\1\2/gi;
        s/EXTENDED[- ]*([^- ]+)[- ]*([0-9]+)/Extended\1\2/gi;
        s/IMPROVED[- ]*([^- ]+)[- ]*([0-9]+)/Improved\1\2/gi;
        s/ROCKET[- ]*LAUNCHER[- ]*([0-9]+)/RocketLauncher\1/gi;
    ')
    
    # Convert to PascalCase with careful acronym handling
    local result=""
    for word in $name; do
        # Skip empty words
        [[ -z "$word" ]] && continue
        
        # Remove dashes/slashes
        word=$(echo "$word" | tr -d '/-')
        
        # Convert known acronyms and terms to proper casing
        case "$word" in
            [Ee][Rr][Pp][Pp][Cc]) result+="ERPPC" ;;
            [Pp][Pp][Cc]) result+="PPC" ;;
            [Ll][Rr][Mm]) result+="LRM" ;;
            [Ss][Rr][Mm]) result+="SRM" ;;
            [Mm][Rr][Mm]) result+="MRM" ;;
            [Aa][Tt][Mm]) result+="ATM" ;;
            [Ee][Cc][Mm]) result+="ECM" ;;
            [Aa][Mm][Ss]) result+="AMS" ;;
            [Tt][Aa][Gg]) result+="TAG" ;;
            [Mm][Gg]) result+="MG" ;;
            [Uu][Aa][Cc]) result+="UltraAutoCannon" ;;
            [Rr][Aa][Cc]) result+="RotaryAutoCannon" ;;
            [Aa][Pp]) result+="AP" ;;
            [Hh][Aa][Gg]) result+="HAG" ;;
            [Ll][Bb][Xx]) result+="LBX" ;;
            [Ll][Bb][Xx][Aa][Cc]) result+="LBXAutoCannon" ;;
            [Ll][Bb][Xx][Aa][Uu][Tt][Oo][Cc][Aa][Nn][Nn][Oo][Nn]) result+="LBXAutoCannon" ;;
            [Aa][Cc]) result+="AutoCannon" ;;
            [Ii][Vv]) result+="IV" ;;
            [Ee][Rr]) result+="ER" ;;
            [Hh][Ee]) result+="HE" ;;
            [Cc][Ee][Ww][Ss]) result+="CEWS" ;;
            [Vv][Ss][Pp]) result+="VSP" ;;
            [Gg][Aa][Uu][Ss][Ss]) result+="Gauss" ;;
            [Ll][Ii][Gg][Hh][Tt][Gg][Aa][Uu][Ss][Ss]) result+="LightGauss" ;;
            [Hh][Ee][Aa][Vv][Yy][Gg][Aa][Uu][Ss][Ss]) result+="HeavyGauss" ;;
            [Ii][Mm][Pp][Rr][Oo][Vv][Ee][Dd][Hh][Ee][Aa][Vv][Yy][Gg][Aa][Uu][Ss][Ss]) result+="ImprovedHeavyGauss" ;;
            [Ss][Ii][Ll][Vv][Ee][Rr][Bb][Uu][Ll][Ll][Ee][Tt][Gg][Aa][Uu][Ss][Ss]) result+="SilverBulletGauss" ;;
            [Mm][Aa][Gg][Ss][Hh][Oo][Tt][Gg][Aa][Uu][Ss][Ss]) result+="MagshotGauss" ;;
            [Ii][Mm][Pp][Rr][Oo][Vv][Ee][Dd][Hh][Ee][Aa][Vv][Yy][Ss][Mm][Aa][Ll][Ll][Ll][Aa][Ss][Ee][Rr]) result+="ImprovedHeavySmallLaser" ;;
            [Ii][Mm][Pp][Rr][Oo][Vv][Ee][Dd][Hh][Ee][Aa][Vv][Yy][Mm][Ee][Dd][Ii][Uu][Mm][Ll][Aa][Ss][Ee][Rr]) result+="ImprovedHeavyMediumLaser" ;;
            [Ii][Mm][Pp][Rr][Oo][Vv][Ee][Dd][Hh][Ee][Aa][Vv][Yy][Ll][Aa][Rr][Gg][Ee][Ll][Aa][Ss][Ee][Rr]) result+="ImprovedHeavyLargeLaser" ;;
            *)
                # Convert to proper case for regular words
                first_char=$(echo "${word:0:1}" | tr '[:lower:]' '[:upper:]')
                rest=$(echo "${word:1}" | tr '[:upper:]' '[:lower:]')
                result+="${first_char}${rest}"
                ;;
        esac
    done
    
    # Add variant number if provided
    [[ -n "$variant" ]] && result+="$variant"
    
    echo "$result"
}

# Function to extract variant number from name
get_variant() {
    local name="$1"
    if [[ $name =~ /([0-9]+)$ ]]; then
        echo "${BASH_REMATCH[1]}"
    elif [[ $name =~ ([0-9]+)$ ]]; then
        echo "${BASH_REMATCH[1]}"
    else
        echo ""
    fi
}

# Function to get damage type flags from weapon type
get_damage_type_flags() {
    local type="$1"
    local flags=()
    
    # Map type codes to DamageTypeFlags enum values
    [[ $type == *"DB"* ]] && flags+=("DirectFireBallistic")
    [[ $type == *"DE"* ]] && flags+=("DirectFireEnergy")
    [[ $type == *"M"* ]] && flags+=("Missile")
    [[ $type == *"S"* ]] && flags+=("SwitchableAmmo")
    [[ $type == *"AI"* ]] && flags+=("AntiInfantry")
    [[ $type == *"C"* ]] && flags+=("Cluster")
    [[ $type == *"F"* ]] && flags+=("AreaEffect")  # Flak -> AreaEffect
    [[ $type == *"H"* ]] && flags+=("HeatCausing")
    [[ $type == *"P"* ]] && flags+=("Pulse")
    [[ $type == *"R"* ]] && flags+=("RapidFire")
    [[ $type == *"X"* ]] && flags+=("Explosive")   # Experimental -> Explosive
    [[ $type == *"OS"* ]] && flags+=("OneShot")
    [[ $type == *"V"* ]] && flags+=("VariableDamage")
    [[ $type == *"E"* ]] && flags+=("Electronics")
    [[ $type == *"PB"* ]] && flags+=("PointBlank")
    
    # Construct the flags expression
    if [ ${#flags[@]} -eq 0 ]; then
        echo "DamageTypeFlags.DirectFireBallistic"  # Default if no flags match
    else
        local result=$(IFS=" | " ; echo "DamageTypeFlags.${flags[*]}")
        echo "$result"
    fi
}

# Function to parse ranges from CSV format - USE THE HIGHER NUMBER
parse_range() {
    local range="$1"
    
    # Handle different types of dashes and clean up
    range=$(echo "$range" | tr -d '"' | tr '–—' '-')
    
    if [[ $range =~ ([0-9]+)-([0-9]+) ]]; then
        # Extract the higher number from the range
        echo "${BASH_REMATCH[2]}"
    else
        # If not a range, just extract the number
        echo "$range" | sed 's/[^0-9]//g'
    fi
}

# Function to generate C# class for a weapon
generate_weapon_class() {
    local name="$1"
    local type="$2"
    local heat="$3"
    local damage="$4"
    local min_range="$5"
    local short_range="$6"
    local medium_range="$7"
    local long_range="$8"
    local tonnage="$9"
    local slots="${10}"
    local shots="${11}"
    local namespace="${12}"
    local dry_run="${13:-false}"
    
    # Skip ammo entries
    [[ $name == *"ammo"* ]] && return
    
    # Get variant number and class name
    local variant=$(get_variant "$name")
    local base_name=$(echo "$name" | sed 's/[0-9]*$//' | sed 's/\/$//')
    local class_name=$(normalize_to_class_name "$base_name" "$variant")
    local flags=$(get_damage_type_flags "$type")
    
    # Post-processing for class names to fix specific patterns
    # Fix casing for LBX
    class_name=$(echo "$class_name" | sed -E 's/Lbxautocannon([0-9]+)/LBXAutoCannon\1/g')
    # Fix casing for Light AC
    class_name=$(echo "$class_name" | sed -E 's/Lightac([0-9]+)/LightAutoCannon\1/g')
    # Fix casing for Gauss variants
    class_name=$(echo "$class_name" | sed -E 's/Heavygauss/HeavyGauss/g')
    class_name=$(echo "$class_name" | sed -E 's/Lightgauss/LightGauss/g')
    class_name=$(echo "$class_name" | sed -E 's/Improvedheavygauss/ImprovedHeavyGauss/g')
    class_name=$(echo "$class_name" | sed -E 's/Silverbulletgauss/SilverBulletGauss/g')
    class_name=$(echo "$class_name" | sed -E 's/Magshotgauss/MagshotGauss/g')
    # Fix casing for improved heavy lasers
    class_name=$(echo "$class_name" | sed -E 's/Improvedheavysmalllaser/ImprovedHeavySmallLaser/g')
    class_name=$(echo "$class_name" | sed -E 's/Improvedheavymediumlaser/ImprovedHeavyMediumLaser/g')
    class_name=$(echo "$class_name" | sed -E 's/Improvedheavylargelaser/ImprovedHeavyLargeLaser/g')
    # Fix MG casing
    class_name=$(echo "$class_name" | sed -E 's/Lightmg/LightMG/g')
    class_name=$(echo "$class_name" | sed -E 's/Heavymg/HeavyMG/g')
    
    # Handle damage values - get the first number
    if [[ $damage == *"Msl"* ]] || [[ $damage == *"/"* ]]; then
        damage=$(echo "$damage" | grep -o '[0-9]\+' | head -1)
    elif [[ $damage == *"C"* ]]; then
        damage=$(echo "$damage" | sed 's/C[0-9]*\///' | grep -o '[0-9]\+' | head -1)
    else
        damage=$(echo "$damage" | tr -d '"' | sed 's/[^0-9.]//g')
    fi
    
    # Ensure numeric values are valid
    [[ -z "$damage" ]] && damage=0
    
    # Handle the tonnage - clean it up to get numeric value
    tonnage=$(echo "$tonnage" | tr -d '"' | sed 's/[^0-9.]//g')
    [[ -z "$tonnage" ]] && tonnage=0
    
    # Handle critical slots - get numeric value
    slots=$(echo "$slots" | tr -d '"' | sed 's/[^0-9]//g')
    [[ -z "$slots" ]] && slots=1
    
    # Handle heat - get numeric value
    heat=$(echo "$heat" | tr -d '"' | sed 's/[^0-9.]//g')
    [[ -z "$heat" ]] && heat=0
    
    # Handle minimum range - get numeric value
    min_range=$(echo "$min_range" | tr -d '"' | sed 's/[^0-9.]//g')
    [[ -z "$min_range" ]] && min_range=0
    
    # Parse ranges to get the higher number from each range
    short_range=$(parse_range "$short_range")
    [[ -z "$short_range" ]] && short_range=0
    
    medium_range=$(parse_range "$medium_range")
    [[ -z "$medium_range" ]] && medium_range=0
    
    long_range=$(parse_range "$long_range")
    [[ -z "$long_range" ]] && long_range=0
    
    # Handle shots per ton - get numeric value
    if [[ "$shots" == "OS" ]]; then
        shots=1  # One-shot weapons have 1 shot
    else
        shots=$(echo "$shots" | tr -d '"' | sed 's/[^0-9]//g')
        [[ -z "$shots" ]] && shots=0
    fi
    
    # Set up directory
    local base_dir="MegaMekAbstractions/Mechs/Equipment/Weapons/${namespace}"
    mkdir -p "${base_dir}"
    
    if [[ "$dry_run" == "true" ]]; then
        echo "Would create: ${base_dir}/${class_name}.cs (From: ${name})"
        return
    fi
    
    echo "Creating file: ${base_dir}/${class_name}.cs"
    
    # Remove any double quotes from the name
    name=$(echo "$name" | tr -d '"')
    
    # Write the C# class file with constructor parameters WITHOUT their names
    # Fix the flags format to ensure it only has one flags value
    cat > "${base_dir}/${class_name}.cs" << EOL
namespace MegaMekAbstractions.Mechs.Equipment.Weapons.${namespace};

/// <summary>
/// Represents the ${name} weapon.
/// </summary>
public sealed class ${class_name} : Weapon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="${class_name}"/> class.
    /// </summary>
    public ${class_name}() : base("${name}", ${slots}, ${tonnage}.0m, ${heat}, ${min_range}, ${short_range}, ${medium_range}, ${long_range}, ${damage}, ${flags})
    {
        ShotsPerTon = ${shots};
    }
}
EOL
}

# Check if dry run mode is enabled
DRY_RUN=false
if [[ "$1" == "--dry-run" ]]; then
    DRY_RUN=true
    echo "=== DRY RUN MODE - No files will be created ==="
fi

# Process InnerSphere weapons
echo "Processing InnerSphere weapons..."
while IFS=, read -r name type heat damage min_range short_range medium_range long_range tons slots shots page
do
    [[ $name == "Name" || $name == *"ammo"* ]] && continue
    generate_weapon_class "$name" "$type" "$heat" "$damage" "$min_range" "$short_range" "$medium_range" "$long_range" "$tons" "$slots" "$shots" "InnerSphere" "$DRY_RUN"
done < MegaMekAbstractions/Mechs/Equipment/Weapons/InnerSphere/InnerSphere.csv

# Process Clan weapons
echo "Processing Clan weapons..."
while IFS=, read -r name type heat damage min_range short_range medium_range long_range tons slots shots page
do
    [[ $name == "Name" || $name == *"ammo"* ]] && continue
    generate_weapon_class "$name" "$type" "$heat" "$damage" "$min_range" "$short_range" "$medium_range" "$long_range" "$tons" "$slots" "$shots" "Clan" "$DRY_RUN"
done < MegaMekAbstractions/Mechs/Equipment/Weapons/Clan/Clan.csv

if [[ "$DRY_RUN" == "true" ]]; then
    echo "=== DRY RUN COMPLETE - No files were created ==="
else
    echo "Done generating weapon classes!"
fi
