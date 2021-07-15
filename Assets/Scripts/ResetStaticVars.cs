using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticVars : MonoBehaviour
{
    private AudioClip fxFundo;
    // Start is called before the first frame update
    void Start()
    {
        StaticVar.imgAtiva = -1;
        StaticVar.ClassifiedStars = new List<int>();
        StaticVar.fuel = 14;
        StaticVar.score = 0;
        StaticVar.resources = 150;
        AudioManager.instance.PlaySound(fxFundo);
    }
}
