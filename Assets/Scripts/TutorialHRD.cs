using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHRD : MonoBehaviour
{
    public Text txtTutorial;

    void Start()
    {
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
        txtTutorial.text += " para";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " mover";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " a estrela";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " pelo";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " gráfico.";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " Clique";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " onde";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " acredita";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " que";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " seja";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " a classificação";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " da estrela.";
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
