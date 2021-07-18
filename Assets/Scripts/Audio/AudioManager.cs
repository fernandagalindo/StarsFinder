using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource fxSource;
    public AudioSource Music;

    private AudioSource asMusic; // componete para controlar o volume

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    public void PlaySound(AudioClip clip)
    {
        asMusic = GetComponent<AudioSource>();

        if (StaticVar.volume > 0)
        {
            asMusic.volume = StaticVar.volume;
            fxSource.clip = clip;
            fxSource.Play();
        }
    }
}
