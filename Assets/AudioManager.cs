using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;
    public AudioClip CollectSound;
    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
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
}
