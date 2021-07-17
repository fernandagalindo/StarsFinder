using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigaAudio : MonoBehaviour
{
    public AudioClip fxSound;
    public AudioClip Music;
    void Start()
    {
        AudioManager.instance.PlaySound(Music);
    }
}
