using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SlidersManager : AudioMenu
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Slider _masterSlider;

    public float LastVolume => _lastVolume;

    private float _lastVolume;

    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _effectsSlider.onValueChanged.AddListener(ChangeEffectsVolume);
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        _effectsSlider.onValueChanged.RemoveListener(ChangeEffectsVolume);
        _masterSlider.onValueChanged.RemoveListener(ChangeMasterVolume);
    }

    public void ChangeInteractableSliders(bool state)
    {
        _masterSlider.interactable = state;
        _musicSlider.interactable = state;
        _effectsSlider.interactable = state;
    }

    private void ChangeVolume(string name, float value)
    {
        int multipler = 20;

        Mixer.audioMixer.SetFloat(name, Mathf.Log10(value) * multipler);
        _lastVolume = Mathf.Log10(value) * multipler;
    }

    private void ChangeMasterVolume(float value)
    {
        ChangeVolume(MasterVolume, value);
    }

    private void ChangeMusicVolume(float value)
    {
        ChangeVolume(MusicVolume, value);
    }

    private void ChangeEffectsVolume(float value)
    {
        ChangeVolume(EffectsVolume, value);
    }
}
