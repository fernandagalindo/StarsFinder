using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text txtTime;
    public Text txtRecursos;
    public GameObject goHelp;
    private bool AjudaAtiva = true;

    private void Start()
    {
        ShowHelp();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ContRegressiva();
    }

    public void ContRegressiva()
    {
        StaticVar.timeRemaining -= Time.fixedDeltaTime;
        if (StaticVar.timeRemaining <= 0)
        {
            //--- recebe mais recursos ---
            StaticVar.resources = StaticVar.cngResources;
            txtRecursos.text = StaticVar.resources.ToString();
            StaticVar.timeRemaining = StaticVar.cngRemainingTime;
        }
        txtTime.text = FormatTime(StaticVar.timeRemaining);
    }
    public string FormatTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowHelp()
    {
        if (AjudaAtiva)
        {
            goHelp.SetActive(false);
            AjudaAtiva = false;
        }
        else
        {
            goHelp.SetActive(true);
            AjudaAtiva = true;
        }
    }
}
