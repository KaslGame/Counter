using UnityEngine;
using UnityEngine.Audio;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private int _multipler = 20;

    public void ToggleMasterVolume(bool enabled)
    {
        int minValue = -80;
        int maxValue = 0;

        if (enabled)
            _mixer.audioMixer.SetFloat("MasterVolume", maxValue);
        else
            _mixer.audioMixer.SetFloat("MasterVolume", minValue);
    }

    public void ChangeMasterVolume(float value)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * _multipler);
    }

    public void ChangeMusicVolume(float value)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * _multipler);
    }

    public void ChangeEffectsVolume(float value)
    {
        _mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Log10(value) * _multipler);
    }
}
