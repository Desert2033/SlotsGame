public interface IGameStateMachine
{
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TParameter>(TParameter parameter) where TState : class, IStateWithParameter<TParameter>;
}