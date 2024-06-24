using Gameplay.GameLoop;
using Infrastructure.StateMachines;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
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
      Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();
      Container.BindInterfacesAndSelfTo<StateProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
    }
  }
}