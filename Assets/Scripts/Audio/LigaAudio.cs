using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigaAudio : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.fxSource.Play();
    }
}
