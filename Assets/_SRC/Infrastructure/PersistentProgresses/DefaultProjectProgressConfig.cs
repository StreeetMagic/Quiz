using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  [CreateAssetMenu(fileName = "DefaultProjectProgressConfig", menuName = "Configs/DefaultProjectProgressConfig")]
  public class DefaultProjectProgressConfig : ScriptableObject
  {
    [Tooltip("Включить/выключить музыку")] [Space]
    public bool MusicMute;
  }
}