using Infrastructure.AssetProviders;
using Infrastructure.AudioServices;
using Infrastructure.ConfigProviders;
using Infrastructure.LoadingCurtains;
using Infrastructure.Loggers;
using Infrastructure.PersistentProgresses;
using Infrastructure.RandomServices;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.ZenjectFactories.ProjectContext;
using Zenject;

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