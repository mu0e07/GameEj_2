using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("BGMVolume", 1f);

        audioSource.volume = volume;

        Debug.Log("저장된 볼륨 불러오기 : " + volume);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;

        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();

        Debug.Log("볼륨 저장 : " + volume);
    }
}