using System;
using System.Linq;
using UnityEngine;

namespace Gameplay.GameLoop.Questions
{
  [Serializable]
  public class QuestionSetup
  {
    [field: SerializeField] public string Question { get; private set; }
  
    [SerializeField] private string[] _answers = new string[4];
  
    public string[] Answers => _answers.ToArray();
  }
}