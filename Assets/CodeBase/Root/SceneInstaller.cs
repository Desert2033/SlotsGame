using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private SlotMachine _slotMachine;

    private ISceneObjectsService _sceneObjectsService;

    [Inject]
    public void Construct(ISceneObjectsService sceneObjectsService)
    {
        _sceneObjectsService = sceneObjectsService;
    }

    public override void InstallBindings()
    {
        //base.InstallBindings();

        _sceneObjectsService.SlotMachine = _slotMachine;
    }
}
