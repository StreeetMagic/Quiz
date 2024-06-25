using Gameplay.Questions;
using Infrastructure.ConfigProviders;
using Zenject;

namespace Gameplay
{
  public class CurrentQuestionProvider
  {
    public string Value { get; set; }
    public string[] Answers { get; set; }

    public CurrentQuestionProvider(ConfigProvider configProvider)
    {
      var questionsConfig = configProvider.QuestionsConfig;

      Value = questionsConfig.Questions[0].Question;
      Answers = questionsConfig.Questions[0].Answers;
    }
  }
}