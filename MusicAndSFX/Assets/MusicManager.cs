using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public float startMusicVolume;
    public float startSfxVolume;

    public List<AudioClip> levelMusic;
    //public AudioClip[] levelMusic;
    public AudioClip menuMusic;
    public AudioClip bossMusic;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicVolumeSlider.value = startMusicVolume;
        sfxVolumeSlider.value = startSfxVolume;
        audioSource.volume = startMusicVolume;

        for (int i = 0; i < levelMusic.Count; i++)
        {
            AudioClip temp = levelMusic[i];
            int randomIndex = Random.Range(i, levelMusic.Count);
            levelMusic[i] = levelMusic[randomIndex];
            levelMusic[randomIndex] = temp;
        }
        audioSource.clip = levelMusic[0];
        audioSource.Play();
    }


    public void ChangeVolume(System.Single value)
    {
        audioSource.volume = value;
    }

    public float GetSFXVolume()
    {
        return sfxVolumeSlider.value;
    }
}
