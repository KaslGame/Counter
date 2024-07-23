using UnityEngine;
using UnityEngine.Audio;

public abstract class AudioMenu : MonoBehaviour
{
    protected const string MasterVolume = nameof(MasterVolume);
    protected const string MusicVolume = nameof(MusicVolume);
    protected const string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] protected AudioMixerGroup Mixer;
}
