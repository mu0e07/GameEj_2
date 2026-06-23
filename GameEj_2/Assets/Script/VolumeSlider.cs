using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private BGMManager bgmManager;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("BGMVolume", 1f);

        slider.value = volume;

        bgmManager.SetVolume(volume);

        slider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        bgmManager.SetVolume(value);
    }
}