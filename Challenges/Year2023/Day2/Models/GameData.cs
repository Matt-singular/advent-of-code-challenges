namespace Challenges.Year2023.Day2.Models;

public class GameData(int red = 0, int green = 0, int blue = 0)
{
  public int RedCubes { get; set; } = red;
  public int GreenCubes { get; set; } = green;
  public int BlueCubes { get; set; } = blue;

  public static bool operator >(GameData a, GameData b) => IsGreaterThan(a, b);
  public static bool operator <(GameData a, GameData b) => IsLessThan(a, b);
  public static bool operator >=(GameData a, GameData b) => IsGreaterThanOrEqualTo(a, b);
  public static bool operator <=(GameData a, GameData b) => IsLessThanOrEqualTo(a, b);

  private static bool IsGreaterThan(GameData leftHandValue, GameData rightHandValue)
  {
    var isGreaterThan = leftHandValue.RedCubes > rightHandValue.RedCubes
      && leftHandValue.GreenCubes > rightHandValue.GreenCubes
      && leftHandValue.BlueCubes > rightHandValue.BlueCubes;

    return isGreaterThan;
  }

  private static bool IsLessThan(GameData leftHandValue, GameData rightHandValue)
  {
    var isLessThan = leftHandValue.RedCubes < rightHandValue.RedCubes
      && leftHandValue.GreenCubes < rightHandValue.GreenCubes
      && leftHandValue.BlueCubes < rightHandValue.BlueCubes;

    return isLessThan;
  }

  private static bool IsGreaterThanOrEqualTo(GameData leftHandValue, GameData rightHandValue)
  {
    var isGreaterThanOrEqualTo = leftHandValue.RedCubes >= rightHandValue.RedCubes
      && leftHandValue.GreenCubes >= rightHandValue.GreenCubes
      && leftHandValue.BlueCubes >= rightHandValue.BlueCubes;

    return isGreaterThanOrEqualTo;
  }

  private static bool IsLessThanOrEqualTo(GameData leftHandValue, GameData rightHandValue)
  {
    var isGreaterThanOrEqualTo = leftHandValue.RedCubes <= rightHandValue.RedCubes
      && leftHandValue.GreenCubes <= rightHandValue.GreenCubes
      && leftHandValue.BlueCubes <= rightHandValue.BlueCubes;

    return isGreaterThanOrEqualTo;
  }
}