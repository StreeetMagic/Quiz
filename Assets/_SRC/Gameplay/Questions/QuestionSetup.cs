using System;
using System.Linq;
using UnityEngine;

namespace Gameplay.Questions
{
  [Serializable]
  public class QuestionSetup
  {
    [field: SerializeField] public string Question { get; private set; }

    [SerializeField] private string[] _answers;
  
    public string[] Answers => _answers.ToArray();
  }
}