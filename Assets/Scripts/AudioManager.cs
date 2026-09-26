using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    AudioMixer masterMixer;

    public void ChangeMasterVolume(float volume)
    {
        masterMixer.SetFloat("MasterVolume", Mathf.Log(volume) * 20);
    }

    public void ChangeMusicVolume(float volume)
    {
        masterMixer.SetFloat("MusicVolume", Mathf.Log(volume) * 20);
    }

    public void ChangeSFXVolume(float volume)
    {
        masterMixer.SetFloat("SFXVolume", Mathf.Log(volume) * 20);
    }

}
