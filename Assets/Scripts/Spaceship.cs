using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float XAux = 0.1f;
    public float YAux = 0.05f;
    private float speedMove;
    private float XSize = 0.8f;
    private float YSize = 0.8f;
    private float speedSize;

    void Start()
    {
        speedMove = 0.1f;
        speedSize = 0.01f;
        StartCoroutine(Aproach());
    }

    IEnumerator Aproach()
    {
        while (XAux > 0f)
        {
            //--- movimenta a nave ---
            XAux -= speedMove;
            YAux -= speedMove;
            transform.position = new Vector3(XAux, YAux, 0f);
            //--- aumenta o tamanho ---
            XSize += speedSize;
            YSize += speedSize;
            transform.localScale = new Vector3(XSize, YSize, transform.localScale.z);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
