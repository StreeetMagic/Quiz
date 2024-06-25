using Gameplay;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface
{
  public class QuestionText : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _text;

    private CurrentQuestionProvider _currentQuestionProvider;

    [Inject]
    public void Construct(CurrentQuestionProvider currentQuestionProvider)
    {
      _currentQuestionProvider = currentQuestionProvider;
    }

    private void Awake()
    {
      DisplayText(_currentQuestionProvider.GetCurrentQuestion);
    }
  
    private void OnEnable()
    {
      _currentQuestionProvider.Changed += DisplayText;
    }
  
    private void OnDisable()
    {
      _currentQuestionProvider.Changed -= DisplayText; 
    }

    private void DisplayText(Question question)
    {
      _text.text = question.Text;
    }
  }
}