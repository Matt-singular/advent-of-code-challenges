namespace Challenges.Year2023.Day1;

using System.Text.RegularExpressions;
using Challenges.Helpers;

public class DayOneSolution(IFileHelpers fileHelpers) : IDayOneSolution
{
  public int ProcessPartOne()
  {
    // Solve day one's first problem
    var fileContents = fileHelpers.ReadFileContents(Constants.ChallengeInputFile);
    var digits = GetDigits(fileContents);
    var answer = SumDigits(digits);

    return answer;
  }

  public int ProcessPartTwo()
  {
    // Solve day one's second problem
    var fileContents = fileHelpers.ReadFileContents(Constants.ChallengeInputFile);
    var normalisedContents = NormaliseFileContents(fileContents);
    var digits = GetDigits(normalisedContents);
    var answer = SumDigits(digits);

    return answer;
  }

  public static List<int> GetDigits(List<string> fileContents)
  {
    var digits = new List<int>();

    foreach (var line in fileContents)
    {
      var matches = new Regex(Constants.DigitsPattern).Matches(line);
      var first = matches.First().Value;
      var last = matches.Last().Value;

      var digit = Convert.ToInt32($"{first}{last}");
      digits.Add(digit);
    }

    return digits;
  }

  public static int SumDigits(List<int> digits)
  {
    var sum = digits.Sum(digit => digit);

    return sum;
  }

  public static List<string> NormaliseFileContents(List<string> fileContents)
  {
    // Not the most efficient solution, but it's easy to slot into part one's design without having to rewrite any of the part one logic
    var normalisedFileContents = new List<string>();

    foreach (var line in fileContents)
    {
      var normalisedLine = NormaliseLine(line);

      normalisedFileContents.Add(normalisedLine);
    }

    return normalisedFileContents;
  }

  public static string NormaliseLine(string line)
  {
    foreach (var kvp in Constants.DigitWords)
    {
      var digitWordPattern = kvp.Key;
      var normalisedValue = kvp.Value;

      line = new Regex(digitWordPattern).Replace(line, normalisedValue);
    }

    return line;
  }

  public static class Constants
  {
    public const string ChallengeInputFile = "Year2023\\Day1\\DayOneInput.txt";
    public const string DigitsPattern = @"(\d)";
    public static readonly Dictionary<string, string> DigitWords = new()
    {
      { "one", "o1e" },
      { "two", "t2o" },
      { "three", "t3e" },
      { "four", "4" },
      { "five", "5e" },
      { "six", "6" },
      { "seven", "7n" },
      { "eight", "e8t" },
      { "nine", "n9e" }
    };
  }
}