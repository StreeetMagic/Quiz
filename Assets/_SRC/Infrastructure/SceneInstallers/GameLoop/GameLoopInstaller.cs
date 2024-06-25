using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using UserInterface;
using Zenject;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class GameLoopInstaller : MonoInstaller
  {
    [SerializeField] private MainCanvasRoot _mainCanvasRoot;

    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<GameLoopInitializer>().FromInstance(GetComponent<GameLoopInitializer>()).AsSingle();

      Container.BindInterfacesAndSelfTo<MainCanvasRoot>().FromInstance(_mainCanvasRoot).AsSingle();
      Container.BindInterfacesAndSelfTo<UserIntefaceOperator>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameLoopZenjectFactory>().AsSingle();
    }
  }
}