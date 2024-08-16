using UnityEngine;
using Zenject;

public class GameBootrapper : MonoBehaviour
{
    private IGameStateMachine _gameStateMachine;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
        _gameStateMachine.Enter<GameBootstrapState>();

        DontDestroyOnLoad(this);
    }
}
