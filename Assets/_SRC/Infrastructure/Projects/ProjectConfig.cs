using System.Linq;
using UnityEngine;

namespace Infrastructure.Projects
{
  [CreateAssetMenu(fileName = "ProjectConfig", menuName = "Configs/ProjectConfig")]
  public class ProjectConfig : ScriptableObject
  {
    [field: SerializeField] public int AnswerCount { get; private set; }
    [SerializeField] private char[] _answerLetters;

    public char[] AnswerLetters => _answerLetters.ToArray();
  }
}