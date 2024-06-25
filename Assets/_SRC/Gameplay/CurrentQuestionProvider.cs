using Gameplay.Questions;
using Infrastructure.ConfigProviders;
using Zenject;

namespace Gameplay
{
  public class CurrentQuestionProvider
  {
    public string Value { get; set; }
    public string[] Answers { get; set; }

    private QuestionsConfig _questionsConfig;

    [Inject]
    private void Construct(ConfigProvider configProvider)
    {
      _questionsConfig = configProvider.QuestionsConfig;
    }
    
    public CurrentQuestionProvider()
    {
      Value = _questionsConfig.Questions[0].Question;
      Answers = _questionsConfig.Questions[0].Answers;
    }
  }
}