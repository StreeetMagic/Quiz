using System;
using Utilities;

namespace Gameplay
{
  public class GameMatchStateProvider
  {
    public ReactiveProperty<GameMatchStateId> CurrentState { get; } = new();
  }

  public enum GameMatchStateId
  {
    Unknown = 0,

    MainMenu = 1,
    CreateMatch = 2,
    ChooseAnswer = 3,
    AnswerChoosen = 4,
    ShowRoundResult = 5,
    Win = 6,
    Lose = 7
  }
}