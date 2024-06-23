using System;
using Infrastructure.AudioServices;
using Infrastructure.Projects;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

namespace Scenes._Infrastructure.Scripts.LoadProgress
{
  public class LoadProgressInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SaveLoadService _saveLoadService;
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private AudioService _audioService;

    public void Initialize()
    {
      _saveLoadService.ProgressReaders.Add(_audioService);

      _saveLoadService.LoadProgress();

      _sceneLoader.Load(SceneId.MainMenu);
    }
  }
}

