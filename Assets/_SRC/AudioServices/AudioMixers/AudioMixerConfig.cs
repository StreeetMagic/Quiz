using UnityEngine;
using UnityEngine.Audio;

namespace AudioServices.AudioMixers
{
  [CreateAssetMenu(fileName = "AudioMixerConfig", menuName = "ArtConfigs/AudioMixerConfig")]
  public class AudioMixerConfig : ScriptableObject
  {
    public AudioMixerGroup Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup Enviroment;
    public AudioMixerGroup UIUX;
    public AudioMixerGroup Combat;
  }
}