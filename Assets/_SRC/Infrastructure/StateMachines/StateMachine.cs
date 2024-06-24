namespace Infrastructure.StateMachines
{
  public class StateMachine
  {
    private readonly StateProvider _stateProvider;

    public StateMachine(StateProvider stateProvider)
    {
      _stateProvider = stateProvider;
    }

    public IExitableState ActiveState { get; private set; }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      var state = ChangeState<TState>();
      state.Enter(payload);
    }

    public void Enter<TState, TPayload, TPayload2>(TPayload payload, TPayload2 payload2)
      where TState : class, IPayloadedState<TPayload, TPayload2>
    {
      var state = ChangeState<TState>();
      state.Enter(payload, payload2);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      ActiveState?.Exit();
      var state = _stateProvider.GetState<TState>();
      ActiveState = state;
      return state;
    }
  }
}