using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
  //Continue playing music even after next scene//
  void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public AudioSource AudioSource;

    private float musicVolume = 1f;

    void Start()
    {
        AudioSource.Play();
    }

    // Adjusting volume on the slider//
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateVolume( float volume)
    {
        musicVolume = volume;
    }
}
