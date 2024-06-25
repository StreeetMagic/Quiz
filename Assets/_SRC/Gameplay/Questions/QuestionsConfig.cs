using System.Linq;
using UnityEngine;

namespace Gameplay.Questions
{
  [CreateAssetMenu(fileName = "QuestionsConfig", menuName = "Configs/QuestionsConfig")]
  public class QuestionsConfig : ScriptableObject
  {
    [SerializeField] private QuestionSetup[] _questions;

    public QuestionSetup[] Questions => _questions.ToArray();
  }
}