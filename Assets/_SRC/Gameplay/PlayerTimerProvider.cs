using UnityEngine;
using Zenject;

namespace Gameplay
{
  public class PlayerTimerProvider : ITickable
  {
    private readonly GameMatchStateProvider _gameMatchStateProvider;

    public PlayerTimerProvider(GameMatchStateProvider gameMatchStateProvider)
    {
      _gameMatchStateProvider = gameMatchStateProvider;
      gameMatchStateProvider.CurrentState.ValueChanged += OnStateChanged;
    }

    private void OnStateChanged(GameMatchStateId state)
    {
      if (state == GameMatchStateId.ChooseAnswer)
      {
        Reset();
      }
    }

    public float Value { get; private set; }

    public void Tick()
    {
      if (_gameMatchStateProvider.CurrentState.Value != GameMatchStateId.ChooseAnswer)
        Reset();

      Value += Time.deltaTime;
    }

    private void Reset()
    {
      Value = 0;
    }
  }
}