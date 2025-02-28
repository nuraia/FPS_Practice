using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
  
    public Slider volumnSlider;
    public static AudioManager Instance;
    private AudioSource audioSource;
    public AudioClip CollectSound;
    public AudioClip ShotSound;
    public AudioClip ReloadSound;
    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolumn"))
        {
            PlayerPrefs.GetFloat("musicVolumn", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    private void OnEnable()
    {
        ItemPickup.OnCoinCollected += PlayCollectSound;
    }
    private void OnDisable()
    {
        ItemPickup.OnCoinCollected -= PlayCollectSound;
    }

    public void PlayCollectSound()
    {
        audioSource.PlayOneShot(CollectSound);
        
    }
    public void PlayShotSound()
    {
        audioSource.PlayOneShot(ShotSound);
    }
    public void PlayReloadSound()
    {
        audioSource.PlayOneShot(ReloadSound);
    }
    public void ChangeVolumn()
    {
        AudioListener.volume = volumnSlider.value;
        Save();
    }
    private void Load()
    {
        volumnSlider.value = PlayerPrefs.GetFloat("musicVolumn");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolumn", volumnSlider.value);
    }
}
