namespace MegaMekAbstractions.Mechs.Equipment;

/// <summary>
/// Represents ammunition for weapons
/// </summary>
public class Ammunition : MechEquipment
{
  /// <summary>
  /// Gets or sets the type of ammunition
  /// </summary>
  public required string AmmoType { get; set; }

  /// <summary>
  /// Gets or sets the number of shots
  /// </summary>
  public required int ShotsPerTon { get; set; }
}
