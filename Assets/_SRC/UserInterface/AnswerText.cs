using Gameplay;
using Infrastructure.ConfigProviders;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class AnswerText : MonoBehaviour
  {
    [SerializeField] private AnswerIndexHolder answerIndexHolder;
    [SerializeField] private TextMeshProUGUI _text;

    private CurrentQuestionProvider _currentQuestionProvider;

    [Inject]
    public void Construct(CurrentQuestionProvider currentQuestionProvider)
    {
      _currentQuestionProvider = currentQuestionProvider;
    }

    private void Awake()
    {
      DisplayText(answerIndexHolder.Index.Value);
    }

    private void OnEnable()
    {
      answerIndexHolder.Index.ValueChanged += DisplayText;
    }

    private void OnDisable()
    {
      answerIndexHolder.Index.ValueChanged -= DisplayText;
    }

    private void DisplayText(int index)
    {
      _text.text = _currentQuestionProvider.Answers[index];
    }
  }
}