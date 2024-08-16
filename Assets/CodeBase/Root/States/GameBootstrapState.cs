public class GameBootstrapState : IState
{
    private GameStateMachine _gameStateMachine;
    private IStaticDataService _staticDataService;

    public GameBootstrapState(GameStateMachine gameStateMachine, IStaticDataService staticDataService)
    {
        _gameStateMachine = gameStateMachine;
        _staticDataService = staticDataService;
    }

    public void Enter()
    {
        _staticDataService.LoadSlots();

        _gameStateMachine.Enter<LoadLevelState>();
    }

    public void Exit()
    {
    }
}
