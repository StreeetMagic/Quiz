using Gameplay;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using UserInterface;
using UserInterface.AnswerButtons;
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
      Container.BindInterfacesAndSelfTo<CurrentQuestionProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<QuestionStorage>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameMatchFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameMatchProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameMatchStateProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<CurrentPlayerAnswerIndexHolder>().AsSingle();
      Container.BindInterfacesAndSelfTo<BotAnswerProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerTimerProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<BotTimerProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerAnswerProvider>().AsSingle();
    }
  }
}