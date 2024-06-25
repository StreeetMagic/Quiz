namespace Gameplay
{
  public class GameMatchState
  {
  }

  public enum GameMatchStateId
  {
    Uknown = 0,

    MainMenu = 1,
    CreateMatch = 2,
    ChooseAnswer = 3,
    AnswerChoosen = 4,
    ShowRoundResult = 5,
    WinPanel = 6,
    LosePanel = 7
  }
}