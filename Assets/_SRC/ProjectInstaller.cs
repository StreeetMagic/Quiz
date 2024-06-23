using AssetProviders;
using AudioServices;
using ConfigServices;
using LoadingCurtains;
using Loggers;
using PersistentProgresses;
using RandomServices;
using SaveLoadServices;
using SceneLoaders;
using Unity.VisualScripting;
using Zenject;
using ZenjectFactories.ProjectContext;

public class ProjectInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<ProjectInitilizer.ProjectInitializer>().FromInstance(GetComponent<ProjectInitilizer.ProjectInitializer>()).AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<ProjectZenjectFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<LoadingCurtain>().FromComponentInNewPrefabResource(ProjectConstants.AssetsPath.Prefabs.LoadingCurtain).AsSingle();

    Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();

    Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
    Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();
    Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
    Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<DebugLogger>().AsSingle();

    Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
    Container.BindInterfacesAndSelfTo<ConfigProvider>().AsSingle();
  }
}