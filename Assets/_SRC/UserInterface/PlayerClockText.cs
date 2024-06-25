using Gameplay;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface
{
  public class PlayerClockText : MonoBehaviour
  {
    [Inject] private PlayerTimerProvider _playerTimerProvider;

    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
      _text.text = TimeFormatter.UpdateTimeText(_playerTimerProvider.Value);
    }
  }
}