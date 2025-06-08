using FluentAssertions;
using MegaMekAbstractions.Mechs;
using MegaMekParser.Mtf.Parsers;

namespace MegaMekParser.Mtf.Tests.Parsers;

public class MtfParserSampleFilesTests
{
    private readonly MtfParser _parser = new();

    [Theory]
    [InlineData("Locust LCT-1V.mtf", 20, "Locust", "LCT-1V", 160, EngineType.Standard, 8)]
    [InlineData("Shadow Hawk SHD-2H.mtf", 55, "Shadow Hawk", "SHD-2H", 275, EngineType.Standard, 5)]
    [InlineData("Catapult CPLT-C1.mtf", 65, "Catapult", "CPLT-C1", 260, EngineType.Standard, 4)]
    [InlineData("Warhammer WHM-6R.mtf", 70, "Warhammer", "WHM-6R", 280, EngineType.Standard, 4)]
    [InlineData("Atlas AS7-D.mtf", 100, "Atlas", "AS7-D", 300, EngineType.Standard, 3)]
    [InlineData("Mad Cat (Timber Wolf) Prime.mtf", 75, "Mad Cat", "Prime", 375, EngineType.XL, 5)]
    [InlineData("Archer C 2.mtf", 70, "Archer", "C 2", 280, EngineType.Standard, 4)]
    [InlineData("Rifleman C 3.mtf", 60, "Rifleman", "C 3", 240, EngineType.Standard, 4)]
    [InlineData("Phoenix Hawk C.mtf", 45, "Phoenix Hawk", "C", 270, EngineType.XL, 6)]
    [InlineData("Thor (Summoner) Prime.mtf", 70, "Thor", "Prime", 350, EngineType.XL, 5)]
    [InlineData("Black Hawk (Nova) Prime.mtf", 50, "Black Hawk", "Prime", 250, EngineType.XL, 5)]
    [InlineData("Ryoken (Stormcrow) Prime.mtf", 55, "Ryoken", "Prime", 330, EngineType.XL, 6)]
    [InlineData("Daishi (Dire Wolf) Prime.mtf", 100, "Daishi", "Prime", 300, EngineType.XL, 3)]
    public async Task ParseMechDataAsync_ShouldParseBasicFields(string fileName, int mass, string chassis, string model, int engineRating, EngineType engineType, int walkMp)
    {
        var path = Path.Combine("TestData", "Mechs", fileName);
        var content = await File.ReadAllTextAsync(path);

        var mech = await _parser.ParseMechDataAsync(content);

        mech.Mass.Should().Be(mass);
        mech.Chassis.Should().Be(chassis);
        mech.Model.Should().Be(model);
        mech.Engine.Rating.Should().Be(engineRating);
        mech.Engine.Type.Should().Be(engineType);
        mech.Engine.WalkingMP.Should().Be(walkMp);
    }
}
