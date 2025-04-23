using FluentAssertions;
using MegaMekAbstractions.Parsers.Constants;
using MegaMekAbstractions.Parsers.Interfaces;
using MegaMekParser.Mtf.Parsers;
using MegaMekParser.Mtf.Readers;

namespace MegaMekParser.Mtf.Tests.Readers;

public class MtfFileReaderTests
{
    private readonly MtfFileReader _reader;
    private readonly string _sampleMtfPath;
    private readonly IMtfParser _parser;

    public MtfFileReaderTests()
    {
        _parser = new MtfParser();
        _reader = new MtfFileReader(_parser);
        _sampleMtfPath = Path.Combine("TestData", "Mechs", "MAD-3R.mtf");
    }

    [Fact]
    public async Task ReadFileContentAsync_WithValidFile_ShouldReturnContent()
    {
        // Act
        var content = await _reader.ReadFileContentAsync(_sampleMtfPath);

        // Assert
        content.Should().NotBeNullOrEmpty();
        content.Should().Contain("chassis:Marauder");
        content.Should().Contain("model:MAD-3R");
    }

    [Fact]
    public async Task ReadFileContentAsync_WithNonexistentFile_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var nonexistentFile = "nonexistent.mtf";

        // Act
        var action = () => _reader.ReadFileContentAsync(nonexistentFile);

        // Assert
        await action.Should().ThrowAsync<FileNotFoundException>();
    }

    [Fact]
    public void GetSupportedExtensions_ShouldReturnMtfExtension()
    {
        // Act
        var extensions = _reader.GetSupportedExtensions();

        // Assert
        extensions.Should().NotBeNull();
        extensions.Should().ContainSingle();
        extensions.Should().Contain(MtfConstants.Extensions.Mtf);
    }

    [Fact]
    public void GetParser_WithMtfFile_ShouldReturnParser()
    {
        // Act
        var parser = _reader.GetParser(_sampleMtfPath);

        // Assert
        parser.Should().NotBeNull();
        parser.Should().BeOfType<MtfParser>();
    }

    [Theory]
    [InlineData("mech.txt")]
    [InlineData("mech.mul")]
    [InlineData("")]
    public void GetParser_WithNonMtfFile_ShouldReturnNull(string filePath)
    {
        // Act
        var parser = _reader.GetParser(filePath);

        // Assert
        parser.Should().BeNull();
    }
}
