using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachines
{
  public class StateProvider
  {
    private Dictionary<Type, IExitableState> _states;

    public void Initialize(Dictionary<Type, IExitableState> states)
    {
      _states = states;  
    }

    public TState GetState<TState>() where TState : class, IExitableState
    {
      return _states[typeof(TState)] as TState;
    }
  }
}