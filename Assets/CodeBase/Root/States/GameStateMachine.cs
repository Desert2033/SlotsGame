using System;
using System.Collections.Generic;

public class GameStateMachine : IGameStateMachine
{
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _currentState;

    public GameStateMachine(IStaticDataService staticDataService,
        ISceneLoader sceneLoader,
        ISpinService spinService,
        ISceneObjectsService sceneObjectsService)
    {
        _states = new Dictionary<Type, IExitableState>()
        {
            [typeof(GameBootstrapState)] = new GameBootstrapState(this, staticDataService),
            [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, spinService, sceneObjectsService),
            [typeof(GameLoopState)] = new GameLoopState(this),
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TParameter>(TParameter parameter) where TState : class, IStateWithParameter<TParameter>
    {
        TState state = ChangeState<TState>();
        state.Enter(parameter);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _currentState?.Exit();

        TState state = GetState<TState>();
        _currentState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
        _states[typeof(TState)] as TState;
}
