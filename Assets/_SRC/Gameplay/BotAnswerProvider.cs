using System;
using Utilities;

namespace Gameplay
{
  public class BotAnswerProvider
  {
    public ReactiveProperty<int> Index { get; } = new(int.MaxValue);

    public void GenerateAnswer()
    {
      Index.Value = new Random().Next(0, 4);
    }
  }
}