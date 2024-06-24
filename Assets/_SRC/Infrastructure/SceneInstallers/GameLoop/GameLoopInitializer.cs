using Gameplay.GameLoop.StateMachines;
using Infrastructure.StateMachines;
using UnityEngine;
using Zenject;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class GameLoopInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private StateMachine _stateMachine;
    [Inject] private StateProvider _stateProvider;
    [Inject] private StateFactory _stateFactory;

    public void Initialize()
    {
      _stateProvider.Initialize(_stateFactory.CreateStates());
      _stateMachine.Enter<BootstrapState>();
    }
  }
}