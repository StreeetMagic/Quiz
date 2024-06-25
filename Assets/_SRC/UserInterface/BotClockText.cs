using Gameplay;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface
{
  public class BotClockText : MonoBehaviour
  {
    [Inject] private BotTimerProvider _botTimerProvider;

    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
      _text.text = TimeFormatter.UpdateTimeText(_botTimerProvider.Value);
    }
  }
}