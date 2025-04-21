using FluentAssertions;
using MegaMekAbstractions.Parsers.Exceptions;
using MegaMekParser.Mtf.Parsers;

namespace MegaMekParser.Mtf.Tests.Parsers;

public class MtfParserErrorTests
{
    private readonly MtfParser _parser;
    private readonly string _invalidMtfPath;
    private readonly string _invalidMtfContent;

    public MtfParserErrorTests()
    {
        _parser = new MtfParser();
        _invalidMtfPath = Path.Combine("TestData", "Mechs", "Invalid.mtf");
        _invalidMtfContent = File.ReadAllText(_invalidMtfPath);
    }

    [Fact]
    public void ValidateFormat_WithInvalidFile_ShouldReturnFalse()
    {
        // Act
        var isValid = _parser.ValidateFormat(_invalidMtfContent);

        // Assert
        isValid.Should().BeFalse();
    }

    [Fact]
    public async Task ParseMechDataAsync_WithInvalidContent_ShouldThrowMtfParseException()
    {
        // Act
        var action = () => _parser.ParseMechDataAsync(_invalidMtfContent);

        // Assert
        await action.Should().ThrowAsync<MtfParseException>()
            .WithMessage("*Error parsing MTF file 'unknown' at line 0 in section 'Version': Version or chassis information not found*");
    }

    [Fact]
    public void GetMtfVersion_WithInvalidContent_ShouldThrowMtfParseException()
    {
        // Arrange
        var invalidContent = "Not an MTF file\nNo chassis or version";

        // Act & Assert
        _parser.Invoking(p => p.GetMtfVersion(invalidContent))
            .Should().Throw<MtfParseException>()
            .WithMessage("Error parsing MTF file 'unknown' at line 0 in section 'Version': Version or chassis information not found");
    }

    [Theory]
    [InlineData("Mass", "NotANumber")]
    [InlineData("Engine", "Invalid Rating")]
    [InlineData("Structure", "Unknown Type")]
    [InlineData("Heat Sinks", "Invalid Format")]
    public void GetSection_WithInvalidSections_ShouldContainExpectedInvalidData(string sectionName, string expectedValue)
    {
        // Act
        var section = _parser.GetSection(_invalidMtfContent, $"{sectionName}:");

        // Assert
        section.Should().NotBeNull();
        section.Should().Contain(expectedValue);
    }

    [Fact]
    public void GetSection_WithMissingRequiredSection_ShouldThrowMtfParseException()
    {
        // Act
        var action = () => _parser.GetSection(_invalidMtfContent, "Weapons:");

        // Assert
        action.Should().Throw<MtfParseException>()
            .Which.Message.Should().Contain("not found");
    }

    [Fact]
    public void GetSectionNames_WithInvalidContent_ShouldReturnAllFoundSections()
    {
        // Act
        var sections = _parser.GetSectionNames(_invalidMtfContent);

        // Assert
        sections.Should().NotBeNull();
        sections.Should().Contain("Mass");
        sections.Should().Contain("chassis");
        sections.Should().NotContain("Weapons"); // Doesn't exist in invalid file
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task ParseMechDataAsync_WithEmptyContent_ShouldThrowMtfParseException(string content)
    {
        // Act
        var action = () => _parser.ParseMechDataAsync(content);

        // Assert
        await action.Should().ThrowAsync<MtfParseException>()
            .WithMessage("Error parsing MTF file 'unknown' at line 0 in section 'Content': MTF content is empty");
    }
}
