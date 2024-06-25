using System.Linq;
using UnityEngine;

namespace Infrastructure.Projects
{
  [CreateAssetMenu(fileName = "ProjectConfig", menuName = "Configs/ProjectConfig")]
  public class ProjectConfig : ScriptableObject
  {
    [SerializeField] private char[] _answerLetters;
    
    [field: SerializeField] public int AnswerCount { get; private set; }
    [field: SerializeField] public int QuestionCount { get; private set; }

    public char[] AnswerLetters => _answerLetters.ToArray();
  }
}