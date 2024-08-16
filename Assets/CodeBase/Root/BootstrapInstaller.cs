using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //base.InstallBindings();


        BindSaveLoadService();

        BindPersistentProgressService();

        BindGameFactory();

        BindSceneLoader();

        BindCoroutineRunner();

        BindGameStateMachine();

        BindStaticDataService();

        BindSlotsContainerService();

        BindCombinationService();

        BindSpinService();

        BindSceneObjectsService();
    }

    private void BindSceneObjectsService() => 
        Container.BindInterfacesAndSelfTo<SceneObjectsService>().AsSingle();

    private void BindSpinService() => 
        Container.BindInterfacesAndSelfTo<SpinService>().AsSingle();

    private void BindCombinationService() => 
        Container.BindInterfacesAndSelfTo<CombinationService>().AsSingle();

    private void BindSlotsContainerService() => 
        Container.BindInterfacesAndSelfTo<SlotsContainerService>().AsSingle();

    private void BindStaticDataService() => 
        Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

    private void BindSceneLoader() =>
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

    private void BindCoroutineRunner() => 
        Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefabResource(AssetPath.CoroutineRunnerPath).AsSingle();

    private void BindGameFactory() => 
        Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();

    private void BindPersistentProgressService() => 
        Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();

    private void BindSaveLoadService() => 
        Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();

    private void BindGameStateMachine() => 
        Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
}
