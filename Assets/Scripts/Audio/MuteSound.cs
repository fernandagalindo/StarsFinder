using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    public AudioClip fxSound;
    public AudioClip fxMusic;
    private AudioSource Music;
    public Slider Volume;

    private void Start()
    {
        Music = GetComponent<AudioSource>();
        //Volume = GetComponent<Slider>();
        AudioManager.instance.PlaySound(fxMusic);
        Music.volume = 0.1f;
    }

    public void MuteOnOff()
    {
        bool mutado = AudioManager.instance.fxMusic.mute;
        if (mutado)
        {
            Music.mute = false;
        }
        else
        {
            Music.mute = true;
        }
    }

    public void MudaVolume()
    {
        Music.volume = Volume.value;
    }
}
