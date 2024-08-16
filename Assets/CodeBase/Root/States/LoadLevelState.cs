public class LoadLevelState : IState
{
    private const string NameNextScene = "GameplayScene";

    private GameStateMachine _gameStateMachine;
    private ISceneLoader _sceneLoader;
    private ISpinService _spinService;
    private ISceneObjectsService _sceneObjectsService;

    public LoadLevelState(GameStateMachine gameStateMachine, 
        ISceneLoader sceneLoader,
        ISpinService spinService,
        ISceneObjectsService sceneObjectsService)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _spinService = spinService;
        _sceneObjectsService = sceneObjectsService;
    }

    public void Enter()
    {
        _sceneLoader.Load(NameNextScene, OnLoaded);
    }

    private void OnLoaded()
    {
        _spinService.InitSlots(_sceneObjectsService.SlotMachine);

        _gameStateMachine.Enter<GameLoopState>();
    }

    public void Exit()
    {
    }
}
