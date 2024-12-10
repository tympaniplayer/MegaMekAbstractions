namespace MegaMekAbstractions.Mechs;

public static class Extensions
{
    #region GYRO
    public static Gyro ToGyro(this string gyro)
    {
        return gyro switch
        {
            "Standard Gyro" or "Standard" => Gyro.Standard,
            "XL Gyro" or "XL"  => Gyro.XL,
            "Compact Gyro" or "Compact" => Gyro.Compact,
            "Heavy Duty Gyro" or "Heavy Duty" => Gyro.HeavyDuty,
            "Superheavy Gyro" or "Superheavy" => Gyro.SuperHeavy,
            "None" => Gyro.None,
            _ => Gyro.Unknown
        };
    }
    #endregion
    
    #region COCKPIT

    public static Cockpit ToCockpit(this string cockpit)
    {
        return cockpit switch
        {
            "Standard Cockpit" or "Standard" => Cockpit.Standard,
            "Small Cockpit" or "Small" => Cockpit.Small,
            "Command Console" or "Command" => Cockpit.CommandConsole,
            "Torso-Mounted Cockpit" or "Torso-Mounted" => Cockpit.TorsoMounted,
            "Dual Cockpit" or "Dual" => Cockpit.Dual,
            "Industrial Cockpit" or "Industrial" => Cockpit.Industrial,
            "Primitive Cockpit" or "Primitive" => Cockpit.Primitive,
            "Primitive Industrial Cockpit" or "Primitive Industrial" => Cockpit.PrimitiveIndustrial,
            "Superheavy Cockpit" or "Super Heavy" => Cockpit.Superheavy,
            "Superheavy Tripod Cockpit" or "Superheavy Tripod" => Cockpit.SuperheavyTripod,
            "Tripod Cockpit" or "Tripod" => Cockpit.Tripod,
            "Interface Cockpit" or "Interface" => Cockpit.Interface,
            "Virtual Reality Piloting Pod" or "VRRP" => Cockpit.Vrpp,
            "Quadvee Cockpit" or "Quadvee" => Cockpit.Quadvee,
            "Superheavy Industrial Cockpit" or "Superheavy Industrial" => Cockpit.SuperheavyIndustrial,
            "Superheavy Command Console" or "Superheavy Command" => Cockpit.SuperheavyCommandConsole,
            "Small Command Console" or "Small Command" => Cockpit.SmallCommandConsole,
            "Tripod Industrial Cockpit" or "Tripod Industrial" => Cockpit.TripodIndustrial,
            "Superheavy Tripod Industrial Cockpit" or "Superheavy Tripod Industrial" => Cockpit.SuperheavyTripodIndustrial,
            _ => Cockpit.Unknown
        };
    }
    #endregion
}