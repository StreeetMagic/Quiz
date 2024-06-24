using System;
using System.Collections.Generic;
using Infrastructure.ZenjectFactories.SceneContext;

namespace Infrastructure.StateMachines
{
  public class StateProvider
  {
    private readonly Dictionary<Type, IExitableState> _states;

    public IReadOnlyDictionary<Type, IExitableState> States => _states;

    public StateProvider(GameLoopZenjectFactory gameLoopZenjectFactory)
    {
      _states = new Dictionary<Type, IExitableState>()
      {
        { typeof(BootstrapState), gameLoopZenjectFactory.InstantiateNative<BootstrapState>() },
        { typeof(MainMenuState), gameLoopZenjectFactory.InstantiateNative<MainMenuState>() }
      };
    }
    
    public TState GetState<TState>() where TState : class, IExitableState
    {
      return _states[typeof(TState)] as TState;
    }
  }
}