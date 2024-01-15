namespace Challenges.tests.Year2023;

using Challenges.Helpers;
using Challenges.Year2023.Day1;

public class DayOneTests
{
  [Fact]
  public void TestDayOnePartOneSample()
  {
    // Arrange
    var example = """
      1abc2
      pqr3stu8vwx
      a1b2c3d4e5f
      treb7uchet
      """;
    List<string> sampleFileContents = [.. example.Split('\n')];
    var mockedFileHelpers = Substitute.ForPartsOf<FileHelpers>();
    mockedFileHelpers.Configure().ReadFileContents(DayOneSolution.Constants.ChallengeInputFile).Returns(sampleFileContents);
    var challenge = new DayOneSolution(mockedFileHelpers);

    // Act
    var answer = challenge.ProcessPartOne();

    // Assert
    answer.Should().Be(142);
  }

  [Fact]
  public void TestDayOnePartOneFullInput()
  {
    // Arrange
    var fileHelpers = new FileHelpers();
    var challenge = new DayOneSolution(fileHelpers);

    // Act
    var answer = challenge.ProcessPartOne();

    // Assert
    answer.Should().Be(54916);
  }

  [Fact]
  public void TestDayOnePartTwoSample()
  {
    // Arrange
    var example = """
      two1nine
      eightwothree
      abcone2threexyz
      xtwone3four
      4nineeightseven2
      zoneight234
      7pqrstsixteen
      """;
    List<string> sampleFileContents = [.. example.Split('\n')];
    var mockedFileHelpers = Substitute.ForPartsOf<FileHelpers>();
    mockedFileHelpers.Configure().ReadFileContents(DayOneSolution.Constants.ChallengeInputFile).Returns(sampleFileContents);
    var challenge = new DayOneSolution(mockedFileHelpers);

    // Act
    var answer = challenge.ProcessPartTwo();

    // Assert
    answer.Should().Be(281);
  }

  [Fact]
  public void TestDayOnePartTwoFullInput()
  {
    // Arrange
    var fileHelpers = new FileHelpers();
    var challenge = new DayOneSolution(fileHelpers);

    // Act
    var answer = challenge.ProcessPartTwo();

    // Assert
    answer.Should().Be(54728);
  }
}