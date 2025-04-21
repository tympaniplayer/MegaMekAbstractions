using FluentAssertions;
using MegaMekAbstractions.Parsers.Constants;
using MegaMekParser.Mtf.Parsers;

namespace MegaMekParser.Mtf.Tests;

public class ParserFactoryTests
{
    private readonly ParserFactory _factory;

    public ParserFactoryTests()
    {
        _factory = new ParserFactory();
    }

    [Theory]
    [InlineData("mech.mtf")]
    [InlineData("mech.MTF")]
    [InlineData(@"c:\path\to\mech.mtf")]
    [InlineData(@"/path/to/mech.mtf")]
    public void CreateParser_WithMtfFile_ShouldReturnMtfParser(string filePath)
    {
        // Act
        var parser = _factory.CreateParser(filePath);

        // Assert
        parser.Should().NotBeNull();
        parser.Should().BeOfType<MtfParser>();
    }

    [Theory]
    [InlineData("mech.txt")]
    [InlineData("mech.mul")]
    [InlineData("")]
    [InlineData(null)]
    public void CreateParser_WithNonMtfFile_ShouldReturnNull(string filePath)
    {
        // Act
        var parser = _factory.CreateParser(filePath);

        // Assert
        parser.Should().BeNull();
    }

    [Fact]
    public void CreateParserForFormat_WithMtfFormat_ShouldReturnMtfParser()
    {
        // Act
        var parser = _factory.CreateParserForFormat(MechFileFormat.Mtf);

        // Assert
        parser.Should().NotBeNull();
        parser.Should().BeOfType<MtfParser>();
    }

    [Fact]
    public void CreateParserForFormat_WithUnsupportedFormat_ShouldReturnNull()
    {
        // Act
        var parser = _factory.CreateParserForFormat((MechFileFormat)999);

        // Assert
        parser.Should().BeNull();
    }

    [Fact]
    public void GetSupportedFormats_ShouldReturnMtfFormat()
    {
        // Act
        var formats = _factory.GetSupportedFormats();

        // Assert
        formats.Should().NotBeNull();
        formats.Should().ContainSingle();
        formats.Should().Contain(MechFileFormat.Mtf);
    }

    [Theory]
    [InlineData(MechFileFormat.Mtf)]
    public void GetFormatExtensions_WithMtfFormat_ShouldReturnMtfExtension(MechFileFormat format)
    {
        // Act
        var extensions = _factory.GetFormatExtensions(format);

        // Assert
        extensions.Should().NotBeNull();
        extensions.Should().ContainSingle();
        extensions.Should().Contain(MtfConstants.Extensions.Mtf);
    }

    [Fact]
    public void GetFormatExtensions_WithUnsupportedFormat_ShouldReturnEmptyArray()
    {
        // Act
        var extensions = _factory.GetFormatExtensions((MechFileFormat)999);

        // Assert
        extensions.Should().NotBeNull();
        extensions.Should().BeEmpty();
    }
}
