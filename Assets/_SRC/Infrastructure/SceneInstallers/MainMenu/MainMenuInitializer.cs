using Infrastructure.AudioServices;
using Infrastructure.LoadingCurtains;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

namespace Infrastructure.SceneInstallers.MainMenu
{
  public class MainMenuInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SaveLoadService _saveLoadService;
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private AudioService _audioService;
    [Inject] private LoadingCurtain _loadingCurtain;

    public void Initialize()
    {
      _loadingCurtain.Hide();
    }
  }
}