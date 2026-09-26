using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;
    [Space(5)]
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    public void ChangeMasterVolume(float volume)
    {
        masterVolume = Mathf.Log(volume) * 20;
        masterMixer.SetFloat("MasterVolume", masterVolume);
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume = Mathf.Log(volume) * 20;
        masterMixer.SetFloat("MusicVolume", musicVolume);
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxVolume = Mathf.Log(volume) * 20;
        masterMixer.SetFloat("SFXVolume", sfxVolume);
    }

}
