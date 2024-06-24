﻿using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.GameLoop
{
  public class GameLoopOpenFinishButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    private GameManager _gameManager;
  
    [Inject] private void Construct(GameManager gameManager)
    {
      _gameManager = gameManager;
    }

    private void Awake()
    {
      _button.onClick.AddListener(() => _gameManager.OpenGameLoopFinishWindow());
    }
  }
}