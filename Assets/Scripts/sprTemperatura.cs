using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprTemperatura : MonoBehaviour
{
    private Vector3 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
    }
}
