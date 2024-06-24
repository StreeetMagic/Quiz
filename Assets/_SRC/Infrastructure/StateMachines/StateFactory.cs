using System;
using System.Collections.Generic;
using Gameplay.GameLoop.StateMachines;
using Infrastructure.SceneInstallers.GameLoop;
using Infrastructure.ZenjectFactories.SceneContext;

namespace Infrastructure.StateMachines
{
  public class StateFactory
  {
    private readonly GameLoopZenjectFactory _gameLoopZenjectFactory;

    public StateFactory(GameLoopZenjectFactory gameLoopZenjectFactory)
    {
      _gameLoopZenjectFactory = gameLoopZenjectFactory;
    }

    public Dictionary<Type, IExitableState> CreateStates()
    {
      return new Dictionary<Type, IExitableState>()
      {
        { typeof(BootstrapState), _gameLoopZenjectFactory.InstantiateNative<BootstrapState>() },
        { typeof(MainMenuState), _gameLoopZenjectFactory.InstantiateNative<MainMenuState>() },
        { typeof(ExitMainMenuState), _gameLoopZenjectFactory.InstantiateNative<ExitMainMenuState>() },
        { typeof(ChooseAnswerState), _gameLoopZenjectFactory.InstantiateNative<ChooseAnswerState>() },
        { typeof(ReturnToMainMenuState), _gameLoopZenjectFactory.InstantiateNative<ReturnToMainMenuState>() }
      };
    }
  }
}