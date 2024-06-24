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
      Container.BindInterfacesAndSelfTo<GameLoopInitializer>().FromInstance(GetComponent<GameLoopInitializer>()).AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<MainCanvasRoot>().FromInstance(_mainCanvasRoot).AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<UserIntefaceOperator>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<GameLoopZenjectFactory>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<StateProvider>().AsSingle().NonLazy();
    }
  }
}