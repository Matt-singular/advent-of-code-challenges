namespace Challenges.Year2023.Day2;

using System.Diagnostics; // TODO - going to test using PostSharp (if I can actually get it set up)
using System.Linq;
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
    var gameData = ExtractGameSetData(fileContents);
    var applicableGames = GetApplicableGameValuesForPartTwo(gameData);
    var answer = applicableGames.Sum(game => game.GetProductOfCubes());

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

  public List<GameSets> GetApplicableGamesForPartOne(List<GameSets> gameSets)
  {
    var actualCubes = new GameData(red: 12, green: 13, blue: 14);
    var applicableGames = gameSets
      .Where(gameSet => gameSet.Games.Count > 0
        ? gameSet.Games.All(gameData => gameData <= actualCubes)
        : false)
      .ToList();

    return applicableGames;
  }

  public List<GameData> GetApplicableGameValuesForPartTwo(List<GameSets> gameSets)
  {
    var applicableGameValues = gameSets.Select(gameSet => GetMinCubeDataValueForGameSetForPartTwo(gameSet.Games)).ToList();

    return applicableGameValues;
  }

  public GameData GetMinCubeDataValueForGameSetForPartTwo(List<GameData> games)
  {
    var (maxRed, maxGreen, maxBlue) = (0, 0, 0);

    games.ForEach(game =>
    {
      maxRed = (maxRed == 0 || game.RedCubes > maxRed) ? game.RedCubes : maxRed;
      maxGreen = (maxGreen == 0 || game.GreenCubes > maxGreen) ? game.GreenCubes : maxGreen;
      maxBlue = (maxBlue == 0 || game.BlueCubes > maxBlue) ? game.BlueCubes : maxBlue;
    });

    return new GameData(maxRed, maxGreen, maxBlue);
  }

  /// <summary>
  /// Measures the elapsed time, the number of iterations, and the result of the specified action.
  /// </summary>
  /// <param name="action">The function representing the action to be measured.</param>
  /// <returns>The result of the action, the number of iterations performed, and the elapsed time in milliseconds.</returns>
  //private (IEnumerable<T> result, long iterations, long timeElapsedInTicks) MeasureIterations<T>(Func<IEnumerable<T>> action)
  //{
  //  var stopwatch = new Stopwatch();
  //  var iterations = 0L;

  //  stopwatch.Start();
  //  foreach (var _ in action())
  //  {
  //      iterations++;
  //  }

  //  stopwatch.Stop();

  //  return (action(), iterations, stopwatch.ElapsedTicks);
  //}

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