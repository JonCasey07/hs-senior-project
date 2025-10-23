using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider Slider;
    private float curVolume;

    public void Start()
    {
        Screen.fullScreen = true;
        audioMixer.GetFloat("volume", out curVolume);
        Slider.value = curVolume;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        Debug.Log(isFullScreen);
    }
}
