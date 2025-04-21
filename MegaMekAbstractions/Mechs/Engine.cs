namespace MegaMekAbstractions.Mechs;

/// <summary>
/// Represents a mech's engine
/// </summary>
public class Engine
{
    /// <summary>
    /// Gets or sets the engine rating
    /// </summary>
    public required int Rating { get; set; }

    /// <summary>
    /// Gets or sets the engine type
    /// </summary>
    public required EngineType Type { get; set; }

    /// <summary>
    /// Gets or sets whether the engine uses a core
    /// </summary>
    public bool HasCore { get; set; }

    /// <summary>
    /// Gets or sets the walking movement points
    /// </summary>
    public int WalkingMP { get; set; }

    /// <summary>
    /// Gets or sets the running movement points
    /// </summary>
    public int RunningMP { get; set; }

    /// <summary>
    /// Gets or sets the jumping movement points
    /// </summary>
    public int JumpingMP { get; set; }

    /// <summary>
    /// Gets the sprinting movement points (usually 1.5x running)
    /// </summary>
    public int SprintingMP => (int)(RunningMP * 1.5);
}
