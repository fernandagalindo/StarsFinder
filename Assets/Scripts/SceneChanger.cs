using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        //Debug.Log(StaticVar.Cena);
        if (sceneName == "VOLTAR")
        {
            if (StaticVar.Cena == null || StaticVar.Cena == "Null")
            {
                SceneManager.LoadScene("Inicio");
            } else
            {
                SceneManager.LoadScene(StaticVar.Cena);
            }
        }
        else
        {
            StaticVar.Cena = SceneManager.GetActiveScene().name;
            //Debug.Log(StaticVar.Cena);
            SceneManager.LoadScene(sceneName);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
