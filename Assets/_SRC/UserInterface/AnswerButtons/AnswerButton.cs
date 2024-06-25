using UnityEngine;

namespace UserInterface.AnswerButtons
{
  public class AnswerButton : MonoBehaviour
  {
    [field: SerializeField]
    [field: Range(1, 4)]
    public int Number { get; private set; }
  }
}