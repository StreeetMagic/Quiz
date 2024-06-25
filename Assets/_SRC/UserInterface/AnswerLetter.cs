using Infrastructure.ConfigProviders;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class AnswerLetter : MonoBehaviour
  {
    [FormerlySerializedAs("_answerButton")] [SerializeField]
    private AnswerIndexHolder answerIndexHolder;

    [SerializeField] private TextMeshProUGUI _text;

    private ConfigProvider _configProvider;

    [Inject]
    public void Construct(ConfigProvider configProvider)
    {
      _configProvider = configProvider;
    }

    private void Awake()
    {
      DisplayLetter(answerIndexHolder.Index.Value);
    }

    private void OnEnable()
    {
      answerIndexHolder.Index.ValueChanged += DisplayLetter;
    }

    private void OnDisable()
    {
      answerIndexHolder.Index.ValueChanged -= DisplayLetter;
    }

    private void DisplayLetter(int index)
    {
      char letter = _configProvider.ProjectConfig.AnswerLetters[index];

      _text.text = letter + ":";
    }
  }
}