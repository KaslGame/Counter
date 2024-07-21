using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] private AudioMixerGroup _mixer;

    [SerializeField] private AudioSource _blizzardSource;
    [SerializeField] private AudioSource _bubbleSource;
    [SerializeField] private AudioSource _burnSource;

    [SerializeField] private Toggle _volumeToggle;

    [SerializeField] private Button _blizzardButton;
    [SerializeField] private Button _bubbleButton;
    [SerializeField] private Button _burnButton;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Slider _masterSlider;

    private int _multipler = 20;

    private float _lastVolume;
    private bool _isMute = false;

    private void OnEnable()
    {
        _volumeToggle.onValueChanged.AddListener(ToggleMasterVolume);
        _blizzardButton.onClick.AddListener(_blizzardSource.Play);
        _bubbleButton.onClick.AddListener(_bubbleSource.Play);
        _burnButton.onClick.AddListener(_burnSource.Play);
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _effectsSlider.onValueChanged.AddListener(ChangeEffectsVolume);
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
    }

    private void OnDisable()
    {
        _volumeToggle.onValueChanged.RemoveListener(ToggleMasterVolume);
        _blizzardButton.onClick.RemoveListener(_blizzardSource.Play);
        _bubbleButton.onClick.RemoveListener(_bubbleSource.Play);
        _burnButton.onClick.RemoveListener(_burnSource.Play);
        _musicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        _effectsSlider.onValueChanged.RemoveListener(ChangeEffectsVolume);
        _masterSlider.onValueChanged.RemoveListener(ChangeMasterVolume);
    }

    public void ToggleMasterVolume(bool active)
    {
        int minValue = -80;

        if (active)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _lastVolume);
            _isMute = true;
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, minValue);
            _isMute = false;
        }

        ChangeInteractableSliders(_isMute);
    }

    private void ChangeInteractableSliders(bool state)
    {
        _masterSlider.interactable = state;
        _musicSlider.interactable = state;
        _effectsSlider.interactable = state;
    }

    private void ChangeVolume(string name, float value)
    {
        _mixer.audioMixer.SetFloat(name, Mathf.Log10(value) * _multipler);
        _lastVolume = Mathf.Log10(value) * _multipler;
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