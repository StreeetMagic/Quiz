using System;
using System.Collections.Generic;
using Infrastructure.ConfigProviders;
using UnityEngine;
using Zenject;

namespace Gameplay
{
  public class GameMatchFactory
  {
    private readonly ConfigProvider _configProvider;
    private readonly GameMatchProvider _gameMatchProvider;

    public GameMatchFactory(ConfigProvider configProvider,
      GameMatchStateProvider gameMatchStateProvider, GameMatchProvider gameMatchProvider)
    {
      _configProvider = configProvider;
      _gameMatchProvider = gameMatchProvider;

      gameMatchStateProvider.CurrentState.ValueChanged += Create;
    }

    private void Create(GameMatchStateId state)
    {
      if (state != GameMatchStateId.CreateMatch)
        return;

      if (_configProvider.QuestionsConfig.Questions.Length < _configProvider.ProjectConfig.QuestionCount)
        throw new Exception("Not enough questions");

      List<Question> questions = new List<Question>();

      for (int i = 0; i < _configProvider.ProjectConfig.QuestionCount; i++)
      {
        questions.Add(new Question(_configProvider.QuestionsConfig.Questions[i].Question, _configProvider.QuestionsConfig.Questions[i].Answers));
      }

      while (questions.Count > _configProvider.ProjectConfig.QuestionCount)
      {
        int randomIndex = UnityEngine.Random.Range(0, questions.Count);
        questions.RemoveAt(randomIndex);
      }

      Shuffle(questions);

      _gameMatchProvider.Instance.Value = new GameMatch(questions);
    }

    private void Shuffle(List<Question> questions)
    {
      for (int i = 0; i < questions.Count; i++)
      {
        int randomIndex = UnityEngine.Random.Range(0, questions.Count);
        Question temp = questions[i];
        questions[i] = questions[randomIndex];
        questions[randomIndex] = temp;
      }
    }
  }
}