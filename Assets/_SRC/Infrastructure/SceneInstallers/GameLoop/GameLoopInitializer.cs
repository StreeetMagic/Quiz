using Gameplay;
using Infrastructure.LoadingCurtains;
using UnityEngine;
using UserInterface;
using Zenject;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class GameLoopInitializer : MonoBehaviour, IInitializable
  {
    private LoadingCurtain _loadingCurtain;
    private MainCanvasRoot _root;
    private UserIntefaceOperator _uiOperator;
    
    [Inject] private GameMatchProvider _gameMatchProvider;
    [Inject] private GameMatchFactory _gameMatchFactory;

    [Inject]
    private void Construct(LoadingCurtain loadingCurtain, MainCanvasRoot root, UserIntefaceOperator uiOperator)
    {
      _loadingCurtain = loadingCurtain;
      _root = root;
      _uiOperator = uiOperator;
    }

    public void Initialize()
    {
      _loadingCurtain.Hide();
      _root.DisableAll();
      _uiOperator.Enable(_root.MainMenuHeadsUpDisplay);
      
      _gameMatchProvider.Instance.Value = _gameMatchFactory.Create();
    }
  }
}