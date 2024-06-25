using UnityEngine;

namespace Gameplay
{
  public class BotTimerProvider
  {
    public BotTimerProvider(GameMatchStateProvider gameMatchStateProvider)
    {
      gameMatchStateProvider.CurrentState.ValueChanged += OnStateChanged;
    }

    private void OnStateChanged(GameMatchStateId state)
    {
      if (state == GameMatchStateId.ChooseAnswer)
        GenerateRandom();
    }

    public float Value { get; private set; }

    private void GenerateRandom()
    {
      Value = Random.Range(0, 20);
    }
  }
}