namespace Challenges.tests.Year2023;

using Challenges.Helpers;
using Challenges.Year2023.Day2;

public class DayTwoTests
{
  [Fact]
  public void TestDayTwoPartOneSample()
  {
    // Arrange
    var example = """
      Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
      Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
      Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
      Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
      Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
      """;
    List<string> sampleFileContents = [.. example.Split('\n')];
    var mockedFileHelpers = Substitute.ForPartsOf<FileHelpers>();
    mockedFileHelpers.Configure().ReadFileContents(DayTwoSolution.Constants.ChallengeInputFile).Returns(sampleFileContents);
    var challenge = new DayTwoSolution(mockedFileHelpers);

    // Act
    var answer = challenge.ProcessPartOne();

    // Assert
    answer.Should().Be(8);
  }

  [Fact]
  public void TestDayTwoPartOneFullInput()
  {
    // Arrange
    var fileHelpers = new FileHelpers();
    var challenge = new DayTwoSolution(fileHelpers);

    // Act
    var answer = challenge.ProcessPartOne();

    // Assert
    answer.Should().Be(2486);
  }

  [Fact]
  public void TestDayTwoPartTwoSample()
  {
    // Arrange
    var example = """
      Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
      Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
      Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
      Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
      Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
      """;
    List<string> sampleFileContents = [.. example.Split('\n')];
    var mockedFileHelpers = Substitute.ForPartsOf<FileHelpers>();
    mockedFileHelpers.Configure().ReadFileContents(DayTwoSolution.Constants.ChallengeInputFile).Returns(sampleFileContents);
    var challenge = new DayTwoSolution(mockedFileHelpers);

    // Act
    var answer = challenge.ProcessPartTwo();

    // Assert
    answer.Should().Be(2286);
  }

  [Fact]
  public void TestDayTwoPartTwoFullInput()
  {
    // Arrange
    var fileHelpers = new FileHelpers();
    var challenge = new DayTwoSolution(fileHelpers);

    // Act
    var answer = challenge.ProcessPartTwo();

    // Assert
    answer.Should().Be(87984);
  }
}