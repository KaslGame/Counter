using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : AudioMenu
{
    [SerializeField] private AudioSource _blizzardSource;
    [SerializeField] private AudioSource _bubbleSource;
    [SerializeField] private AudioSource _burnSource;

    [SerializeField] private Button _blizzardButton;
    [SerializeField] private Button _bubbleButton;
    [SerializeField] private Button _burnButton;

    private void OnEnable()
    {
        _blizzardButton.onClick.AddListener(_blizzardSource.Play);
        _bubbleButton.onClick.AddListener(_bubbleSource.Play);
        _burnButton.onClick.AddListener(_burnSource.Play);
    }

    private void OnDisable()
    {
        _blizzardButton.onClick.RemoveListener(_blizzardSource.Play);
        _bubbleButton.onClick.RemoveListener(_bubbleSource.Play);
        _burnButton.onClick.RemoveListener(_burnSource.Play);
    }
}
