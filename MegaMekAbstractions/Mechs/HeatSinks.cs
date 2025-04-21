namespace MegaMekAbstractions.Mechs;

/// <summary>
/// Represents a mech's heat sink system
/// </summary>
public class HeatSinks
{
    /// <summary>
    /// Gets or sets the type of heat sinks
    /// </summary>
    public required HeatSinkType Type { get; set; }
    
    /// <summary>
    /// Gets or sets the total number of heat sinks
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Gets or sets the number of heat sinks in the engine
    /// </summary>
    public int CountInEngine { get; set; }
    
    /// <summary>
    /// Gets the heat dissipation per sink
    /// </summary>
    public int DissipationPerSink => Type switch
    {
        HeatSinkType.Single => 1,
        HeatSinkType.Double => 2,
        HeatSinkType.Compact => 2,
        HeatSinkType.Laser => 2,
        HeatSinkType.Prototype_Double => 2,
        HeatSinkType.Prototype_Laser => 2,
        _ => 1
    };
    
    /// <summary>
    /// Gets the total heat dissipation capacity
    /// </summary>
    public int TotalDissipation => Count * DissipationPerSink;
}
