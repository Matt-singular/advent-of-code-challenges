namespace Challenges.Year2023.Day2.Models;

//public class GameSets(int gameSetId, List<GameData> games)
public class GameSets(int gameSetId, IEnumerable<GameData> games)
{
  public int GameSetId { get; set; } = gameSetId;
  //public List<GameData> Games { get; set; } = games;
  public IEnumerable<GameData> Games { get; set; } = games;
}