using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    public AudioClip fxSound;
    public AudioClip Music;
    private AudioSource asMusic;
    public Slider Volume;

    private void Start()
    {
        asMusic = GetComponent<AudioSource>();
        //Volume = GetComponent<Slider>();
        AudioManager.instance.PlaySound(Music);
        asMusic.volume = 0.1f;
        Volume.value = StaticVar.volume;
    }

    public void MuteOnOff()
    {
        bool mutado = AudioManager.instance.Music.mute;
        if (mutado)
        {
            asMusic.mute = false;
        }
        else
        {
            asMusic.mute = true;
        }
    }

    public void MudaVolume()
    {
        asMusic.volume = Volume.value;
        StaticVar.volume = asMusic.volume;
    }
}
