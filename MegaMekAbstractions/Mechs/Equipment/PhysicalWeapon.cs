namespace MegaMekAbstractions.Mechs.Equipment;

/// <summary>
/// Represents physical equipment (like MASC, TSM, etc.)
/// </summary>
public class PhysicalWeapon : MechEquipment
{
  /// <summary>
  /// Gets or sets the weapon's damage
  /// </summary>
  public required int Damage { get; set; }

  /// <summary>
  /// Gets or sets any special effects or rules
  /// </summary>
  public string SpecialEffect { get; set; } = string.Empty;
}
