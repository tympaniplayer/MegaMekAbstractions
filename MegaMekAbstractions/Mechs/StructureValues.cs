namespace MegaMekAbstractions.Mechs;

/// <summary>
/// Represents internal structure values for each mech location
/// </summary>
public class StructureValues
{
    /// <summary>
    /// Gets or sets the structure type
    /// </summary>
    public required StructureType Type { get; set; }

    /// <summary>
    /// Gets or sets the head internal structure value
    /// </summary>
    public int Head { get; set; }

    /// <summary>
    /// Gets or sets the center torso internal structure value
    /// </summary>
    public int CenterTorso { get; set; }

    /// <summary>
    /// Gets or sets the left torso internal structure value
    /// </summary>
    public int LeftTorso { get; set; }

    /// <summary>
    /// Gets or sets the right torso internal structure value
    /// </summary>
    public int RightTorso { get; set; }

    /// <summary>
    /// Gets or sets the left arm internal structure value
    /// </summary>
    public int LeftArm { get; set; }

    /// <summary>
    /// Gets or sets the right arm internal structure value
    /// </summary>
    public int RightArm { get; set; }

    /// <summary>
    /// Gets or sets the left leg internal structure value
    /// </summary>
    public int LeftLeg { get; set; }

    /// <summary>
    /// Gets or sets the right leg internal structure value
    /// </summary>
    public int RightLeg { get; set; }

    /// <summary>
    /// Gets the internal structure value for a specific location
    /// </summary>
    public int GetStructureValue(Location location) => location switch
    {
        Location.Head => Head,
        Location.CenterTorso => CenterTorso,
        Location.LeftTorso => LeftTorso,
        Location.RightTorso => RightTorso,
        Location.LeftArm => LeftArm,
        Location.RightArm => RightArm,
        Location.LeftLeg => LeftLeg,
        Location.RightLeg => RightLeg,
        _ => 0
    };

    /// <summary>
    /// Sets the internal structure value for a specific location
    /// </summary>
    public void SetStructureValue(Location location, int value)
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
        }
    }
}
