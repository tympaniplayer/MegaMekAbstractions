using FluentAssertions;
using MegaMekAbstractions.Common;
using MegaMekAbstractions.Mechs;
using MegaMekAbstractions.Parsers.Exceptions;
using MegaMekParser.Mtf.Parsers;

namespace MegaMekParser.Mtf.Tests.Parsers;

public class MtfParserTests
{
    private readonly MtfParser _parser;
    private readonly string _sampleMtfPath;
    private readonly string _sampleMtfContent;

    public MtfParserTests()
    {
        _parser = new MtfParser();
        _sampleMtfPath = Path.Combine("TestData", "Mechs", "MAD-3R.mtf");
        _sampleMtfContent = File.ReadAllText(_sampleMtfPath);
    }

    [Fact]
    public async Task ParseMechDataAsync_WithValidContent_ShouldReturnMech()
    {
        // Arrange
        // Content loaded in constructor

        // Act
        var mech = await _parser.ParseMechDataAsync(_sampleMtfContent);

        // Assert
        mech.Should().NotBeNull();
        mech.Mass.Should().Be(75);
        mech.Chassis.Should().Be("Marauder");
        mech.Model.Should().Be("MAD-3R");
        mech.TechBase.Should().Be(TechBase.InnerSphere);
        mech.Source.Should().Be("TRO 3039 - Early Succession War");
        mech.Configuration.Should().Be(Configuration.Biped);
        
        // Engine details
        mech.Engine.Rating.Should().Be(300);
        mech.Engine.Type.Should().Be(EngineType.XL);
        mech.Engine.WalkingMP.Should().Be(4);
        mech.Engine.JumpingMP.Should().Be(0);
        
        // Systems
        mech.Structure.Type.Should().Be(StructureType.Standard);
        mech.Gyro.Should().Be(Gyro.Standard);
        mech.Cockpit.Should().Be(Cockpit.Standard);
        
        // Heat sinks
        mech.HeatSinks.Type.Should().Be(HeatSinkType.Double);
        mech.HeatSinks.Count.Should().Be(16);
        
        // Armor
        mech.Armor.Type.Should().Be(ArmorType.Standard);
        mech.Armor.Head.Should().Be(9);
        mech.Armor.CenterTorso.Should().Be(23);
        mech.Armor.CenterTorsoRear.Should().Be(7);
        mech.Armor.RightTorso.Should().Be(17);
        mech.Armor.RightTorsoRear.Should().Be(6);
        mech.Armor.LeftTorso.Should().Be(17);
        mech.Armor.LeftTorsoRear.Should().Be(6);
        mech.Armor.RightArm.Should().Be(17);
        mech.Armor.LeftArm.Should().Be(17);
        mech.Armor.RightLeg.Should().Be(18);
        mech.Armor.LeftLeg.Should().Be(18);
    }

    [Fact]
    public void ValidateFormat_WithValidContent_ShouldReturnTrue()
    {
        // Act
        var isValid = _parser.ValidateFormat(_sampleMtfContent);

        // Assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void ValidateFormat_WithInvalidContent_ShouldReturnFalse()
    {
        // Arrange
        var invalidContent = "Not a valid MTF file";

        // Act
        var isValid = _parser.ValidateFormat(invalidContent);

        // Assert
        isValid.Should().BeFalse();
    }

    [Fact]
    public void GetMtfVersion_WithValidContent_ShouldReturnVersion()
    {
        // Act
        var version = _parser.GetMtfVersion(_sampleMtfContent);

        // Assert
        version.Should().Be("1.0");
    }

    [Fact]
    public void GetMtfVersion_WithInvalidContent_ShouldThrowException()
    {
        // Arrange
        var invalidContent = "Not a valid MTF file";

        // Act
        var action = () => _parser.GetMtfVersion(invalidContent);

        // Assert
        action.Should().Throw<MtfParseException>()
            .Which.Message.Should().Contain("Version information not found");
    }

    [Fact]
    public void GetSection_WithValidSection_ShouldReturnSectionContent()
    {
        // Act
        var armorSection = _parser.GetSection(_sampleMtfContent, "Armor:");

        // Assert
        armorSection.Should().NotBeNull();
        armorSection.Should().Contain("Standard");
    }

    [Fact]
    public void GetSection_WithInvalidSection_ShouldThrowException()
    {
        // Act
        var action = () => _parser.GetSection(_sampleMtfContent, "NonexistentSection:");

        // Assert
        action.Should().Throw<MtfParseException>()
            .Which.Message.Should().Contain("not found");
    }

    [Fact]
    public void GetSectionNames_ShouldReturnAllSections()
    {
        // Act
        var sections = _parser.GetSectionNames(_sampleMtfContent);

        // Assert
        sections.Should().Contain(new[] {
            "Version",
            "Mass",
            "Chassis",
            "Model",
            "Tech Base",
            "Config",
            "Engine",
            "Structure",
            "Gyro",
            "Cockpit",
            "Heat Sinks",
            "Armor"
        });
    }
}
