namespace Challenges.Year2023.Day2;

using System.Text.RegularExpressions;
using Challenges.Helpers;
using Challenges.Year2023.Day2.Models;

public class DayTwoSolution(IFileHelpers fileHelpers) : IDayTwoSolution
{
  public int ProcessPartOne()
  {
    // Solve day one's first problem
    var fileContents = fileHelpers.ReadFileContents(Constants.ChallengeInputFile);
    var gameData = ExtractGameSetData(fileContents);
    var applicableGames = GetApplicableGamesForPartOne(gameData);
    var answer = applicableGames.Sum(game => game.GameSetId);

    return answer;
  }

  public int ProcessPartTwo()
  {
    // Solve day one's second problem
    var fileContents = fileHelpers.ReadFileContents(Constants.ChallengeInputFile);
    var answer = -1;

    return answer;
  }

  public List<GameSets> ExtractGameSetData(List<string> fileContents)
  {
    var games = new List<GameSets>();

    foreach (var line in fileContents)
    {
      // Destructive extract of the game id from the string
      var sanitisedLine = line.Trim().ToLowerInvariant();
      var fullGameIdString = sanitisedLine.Substring(0, sanitisedLine.IndexOf(Constants.GameIdEnd)+1);
      var gameIdString = new Regex(Constants.NumberPattern).Match(fullGameIdString).Value;
      var remainingLine = sanitisedLine.Replace(fullGameIdString, string.Empty);

      // Get the game data
      var gamesInSet = remainingLine.Split(Constants.GameSeparator);
      var gameData = gamesInSet.Select(ExtractGameData).ToList();

      // Add to the list
      var gameValues = new GameSets(Convert.ToInt32(gameIdString), gameData);
      games.Add(gameValues);
    }

    return games;
  }

  public GameData ExtractGameData(string gameContent)
  {
    int getGameData(string cubePattern)
    {
      // Get the cube colour count via regexes
      var cubeColourString = new Regex(cubePattern).Match(gameContent)?.Value ?? string.Empty;
      var cubeColourCountString = new Regex(Constants.NumberPattern).Match(cubeColourString)?.Value;

      // Convert the cube colour count to an  integer and return it
      var cubeColourCount = string.IsNullOrWhiteSpace(cubeColourCountString) ? Constants.DefaultCubeCount : cubeColourCountString;
      var cubeCountConverted = Convert.ToInt32(cubeColourCount);
      return cubeCountConverted;
    }

    // Get the counts for each cube type
    var red = getGameData(Constants.CubeColourRed);
    var green = getGameData(Constants.CubeColourGreen);
    var blue = getGameData(Constants.CubeColourBlue);

    return new GameData(red, green, blue);
  } 

  public List<GameSets> GetApplicableGamesForPartOne(List<GameSets> gameData)
  {
    var actualCubes = new GameData(red: 12, green: 13, blue: 14);
    var applicableGames = gameData
      .Where(gameSets => gameSets.Games.Count > 0
        ? gameSets.Games.All(game => game <= actualCubes)
        : false)
      .ToList();

    return applicableGames;
  }

  /// <summary>
  /// Constants relevant to the Day Two solution
  /// </summary>
  public static class Constants
  {
    public const string ChallengeInputFile = "Year2023\\Day2\\DayTwoInput.txt";
    public const string GameIdEnd = ":";
    public const string NumberPattern = @"(\d+)"; // Game Id, Number of cubes
    public const string CubeColourRed = @"(\d+ red)";
    public const string CubeColourGreen = @"(\d+ green)";
    public const string CubeColourBlue = @"(\d+ blue)";
    public const string CubeColourSeparator = ",";
    public const string GameSeparator = ";";
    public const string DefaultCubeCount = "0";
  }
}