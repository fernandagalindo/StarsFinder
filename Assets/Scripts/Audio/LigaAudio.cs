using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigaAudio : MonoBehaviour
{
    public AudioClip fxSound;
    public AudioClip Music;
    private AudioSource Controlador;
    void Start()
    {
        AudioManager.instance.PlaySound(Music);
        Controlador = gameObject.GetComponent<AudioSource>();
        Controlador.volume = StaticVar.volume;
    }
}
