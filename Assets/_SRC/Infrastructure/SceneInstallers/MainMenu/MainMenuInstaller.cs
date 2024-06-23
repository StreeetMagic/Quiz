using Zenject;

namespace Infrastructure.SceneInstallers.MainMenu
{
  public class MainMenuInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<MainMenuInitializer>().FromInstance(GetComponent<MainMenuInitializer>()).AsSingle().NonLazy();
    }
  }
}