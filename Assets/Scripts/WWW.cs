using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWW : MonoBehaviour
{
    public AudioClip fxSound;
    public AudioClip Music;

    private void Start()
    {
        AudioManager.instance.PlaySound(Music);
    }
    public void AbreSite(string link)
    {
        Application.OpenURL(link);
    }
}
