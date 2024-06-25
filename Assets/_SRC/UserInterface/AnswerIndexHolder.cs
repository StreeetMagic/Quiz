using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UserInterface.AnswerButtons
{
  public class AnswerIndexHolder : MonoBehaviour
  {
    public ReactiveProperty<int> Index = new();
  }
}