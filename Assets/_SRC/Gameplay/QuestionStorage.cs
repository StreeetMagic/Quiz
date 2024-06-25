using System.Collections.Generic;
using Gameplay.Questions;
using Infrastructure.ConfigProviders;

namespace Gameplay
{
  public class QuestionStorage
  {
    public List<Question> Questions { get; set; }

    private readonly ConfigProvider _configProvider;

    public QuestionStorage(ConfigProvider configProvider)
    {
      _configProvider = configProvider;

      Create();
    }

    private void Create()
    {
      List<Question> questions = new List<Question>();

      foreach (QuestionSetup question in _configProvider.QuestionsConfig.Questions)
      {
        questions.Add(new Question(question.Question, question.Answers));
      }

      Questions = questions;
    }
  }
}