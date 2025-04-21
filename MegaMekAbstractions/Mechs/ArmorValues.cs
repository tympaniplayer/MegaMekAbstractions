namespace MegaMekAbstractions.Mechs;

/// <summary>
/// Represents armor values for each mech location
/// </summary>
public class ArmorValues
{
    /// <summary>
    /// Gets or sets the armor type
    /// </summary>
    public required ArmorType Type { get; set; }

    /// <summary>
    /// Gets or sets the head armor value
    /// </summary>
    public int Head { get; set; }

    /// <summary>
    /// Gets or sets the center torso armor value
    /// </summary>
    public int CenterTorso { get; set; }

    /// <summary>
    /// Gets or sets the left torso armor value
    /// </summary>
    public int LeftTorso { get; set; }

    /// <summary>
    /// Gets or sets the right torso armor value
    /// </summary>
    public int RightTorso { get; set; }

    /// <summary>
    /// Gets or sets the left arm armor value
    /// </summary>
    public int LeftArm { get; set; }

    /// <summary>
    /// Gets or sets the right arm armor value
    /// </summary>
    public int RightArm { get; set; }

    /// <summary>
    /// Gets or sets the left leg armor value
    /// </summary>
    public int LeftLeg { get; set; }

    /// <summary>
    /// Gets or sets the right leg armor value
    /// </summary>
    public int RightLeg { get; set; }

    /// <summary>
    /// Gets or sets the center torso rear armor value
    /// </summary>
    public int CenterTorsoRear { get; set; }

    /// <summary>
    /// Gets or sets the left torso rear armor value
    /// </summary>
    public int LeftTorsoRear { get; set; }

    /// <summary>
    /// Gets or sets the right torso rear armor value
    /// </summary>
    public int RightTorsoRear { get; set; }

    /// <summary>
    /// Gets the armor value for a specific location
    /// </summary>
    public int GetArmorValue(Location location) => location switch
    {
        Location.Head => Head,
        Location.CenterTorso => CenterTorso,
        Location.LeftTorso => LeftTorso,
        Location.RightTorso => RightTorso,
        Location.LeftArm => LeftArm,
        Location.RightArm => RightArm,
        Location.LeftLeg => LeftLeg,
        Location.RightLeg => RightLeg,
        Location.CenterTorsoRear => CenterTorsoRear,
        Location.LeftTorsoRear => LeftTorsoRear,
        Location.RightTorsoRear => RightTorsoRear,
        _ => 0
    };

    /// <summary>
    /// Sets the armor value for a specific location
    /// </summary>
    public void SetArmorValue(Location location, int value)
    {
        switch (location)
        {
            case Location.Head:
                Head = value;
                break;
            case Location.CenterTorso:
                CenterTorso = value;
                break;
            case Location.LeftTorso:
                LeftTorso = value;
                break;
            case Location.RightTorso:
                RightTorso = value;
                break;
            case Location.LeftArm:
                LeftArm = value;
                break;
            case Location.RightArm:
                RightArm = value;
                break;
            case Location.LeftLeg:
                LeftLeg = value;
                break;
            case Location.RightLeg:
                RightLeg = value;
                break;
            case Location.CenterTorsoRear:
                CenterTorsoRear = value;
                break;
            case Location.LeftTorsoRear:
                LeftTorsoRear = value;
                break;
            case Location.RightTorsoRear:
                RightTorsoRear = value;
                break;
        }
    }
}
