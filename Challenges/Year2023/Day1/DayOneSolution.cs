namespace Challenges.Year2023.Day1;

using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Challenges.Helpers;
using Microsoft.VisualBasic;

public class DayOneSolution(IFileHelpers fileHelpers) : IDayOneSolution
{
  public static class Constants
  {
    public const string ChallengeInputFile = "Year2023\\Day1\\DayOneInput.txt";
  }

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
      var pattern = @"(\d)";
      var matches = new Regex(pattern).Matches(line);

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
      // Very simplistic solution, might write something more elegant later
      var normalisedLine = NormaliseLine(line, "one");
      normalisedLine = NormaliseLine(normalisedLine, "two");
      normalisedLine = NormaliseLine(normalisedLine, "three");
      normalisedLine = NormaliseLine(normalisedLine, "four");
      normalisedLine = NormaliseLine(normalisedLine, "five");
      normalisedLine = NormaliseLine(normalisedLine, "six");
      normalisedLine = NormaliseLine(normalisedLine, "seven");
      normalisedLine = NormaliseLine(normalisedLine, "eight");
      normalisedLine = NormaliseLine(normalisedLine, "nine");

      normalisedFileContents.Add(normalisedLine);
    }

    return normalisedFileContents;
  }

  public static string NormaliseLine(string line, string pattern)
  {
    var normalisedLine = pattern switch
    {
      "one" => new Regex(pattern).Replace(line, "o1e"),
      "two" => new Regex(pattern).Replace(line, "t2o"),
      "three" => new Regex(pattern).Replace(line, "t3e"),
      "four" => new Regex(pattern).Replace(line, "4"),
      "five" => new Regex(pattern).Replace(line, "5e"),
      "six" => new Regex(pattern).Replace(line, "6"),
      "seven" => new Regex(pattern).Replace(line, "7n"),
      "eight" => new Regex(pattern).Replace(line, "e8t"),
      "nine" => new Regex(pattern).Replace(line, "n9e"),
      _ => line
    } ;

    return normalisedLine;
  }
}