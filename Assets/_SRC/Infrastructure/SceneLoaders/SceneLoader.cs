using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneLoaders
{
  public class SceneLoader
  {
    private readonly List<SceneId> _loadedScenes = new();

    public event Action<SceneId> SceneLoaded;
    public List<SceneId> LoadedScenes => _loadedScenes.ToList();
    public SceneId CurrentScene { get; private set; }

    public void Load(SceneId name, Action onLoaded = null)
    {
      if (name == SceneId.Unknown)
        throw new ArgumentException(nameof(name));

      LoadSceneAsync(name, onLoaded).Forget();
    }

    private async UniTaskVoid LoadSceneAsync(SceneId nextScene, Action onLoaded)
    {
      Debug.Log("Начал грузить сцену: " + nextScene);

      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextScene.ToString());

      if (asyncOperation != null)
      {
        asyncOperation.allowSceneActivation = true;

        await asyncOperation.ToUniTask();
      }

      _loadedScenes.Add(nextScene);

      onLoaded?.Invoke();
      SceneLoaded?.Invoke(nextScene);
      CurrentScene = nextScene;
    }

    private void LoadScene(SceneId nextScene, Action onLoaded = null)
    {
      SceneManager.LoadScene(nextScene.ToString());
      _loadedScenes.Add(nextScene);

      onLoaded?.Invoke();
      SceneLoaded?.Invoke(nextScene);
      CurrentScene = nextScene;
    }
  }
}