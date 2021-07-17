using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        if (sceneName == "VOLTAR")
        {
            SceneManager.LoadScene(StaticVar.Cena);
        }
        else
        {
            StaticVar.Cena = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
