using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWW : MonoBehaviour
{
    public void AbreSite(string link)
    {
        Application.OpenURL(link);
    }
}
