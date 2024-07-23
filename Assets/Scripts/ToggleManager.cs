using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : AudioMenu
{
    [SerializeField] private Toggle _volumeToggle;
    [SerializeField] private SlidersManager _slidersManager;

    private bool _isMute = false;

    private void OnEnable()
    {
        _volumeToggle.onValueChanged.AddListener(ToggleMasterVolume);
    }

    private void OnDisable()
    {
        _volumeToggle.onValueChanged.RemoveListener(ToggleMasterVolume);
    }

    public void ToggleMasterVolume(bool active)
    {
        int minValue = -80;

        if (active)
        {
            Mixer.audioMixer.SetFloat(MasterVolume, _slidersManager.LastVolume);
            _isMute = true;
        }
        else
        {
            Mixer.audioMixer.SetFloat(MasterVolume, minValue);
            _isMute = false;
        }

        _slidersManager.ChangeInteractableSliders(_isMute);
    }
}