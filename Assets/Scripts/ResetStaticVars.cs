using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticVars : MonoBehaviour
{
    private AudioClip Music;
    // Start is called before the first frame update
    void Start()
    {
        StaticVar.imgAtiva = -1;
        StaticVar.ClassifiedStars = new List<int>();
        StaticVar.totClassificadas = 0;
        StaticVar.fuel = 14;
        StaticVar.score = 0;
        StaticVar.resources = StaticVar.cngResources;
        AudioManager.instance.PlaySound(Music);
    }
}
