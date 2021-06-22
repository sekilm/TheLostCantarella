using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
    
    public void SetSfxVolume(float sliderValue)
    {
        mixer.SetFloat("SfxVolume", Mathf.Log10(sliderValue) * 20);
    }
}
