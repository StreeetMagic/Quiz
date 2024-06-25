using UnityEngine;
using UserInterface.AnswerButtons;
using Random = UnityEngine.Random;

namespace UserInterface
{
  public class AnswerPanelsContainer : MonoBehaviour
  {
    [SerializeField] private AnswerIndexHolder[] _answerButtons;

    private void Awake()
    {
      Shuffle();
    }

    public void Shuffle()
    {
      int[] indexes = new int[_answerButtons.Length];

      for (int i = 0; i < indexes.Length; i++)
        indexes[i] = i;

      for (int i = 0; i < indexes.Length; i++)
      {
        int index = Random.Range(i, indexes.Length);
        int temp = indexes[i];
        indexes[i] = indexes[index];
        indexes[index] = temp;
      }

      for (int i = 0; i < indexes.Length; i++)
        _answerButtons[i].Index.Value = indexes[i];
    }
  }
}