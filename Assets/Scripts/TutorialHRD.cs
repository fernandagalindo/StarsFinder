using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHRD : MonoBehaviour
{
    public Text txtTutorial;
    public Image imgMouse;

    void Start()
    {
        StartCoroutine(WriteText());
        StartCoroutine(MexeMouse());
    }

    IEnumerator WriteText()
    {
        txtTutorial.text += "Posicione";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " a estrela";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " no gráfico";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " conforme sua";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " TEMPERATURA e ";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " LUMINOSIDADE.";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += "\r\n\r\n";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " Clique";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " para";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " confirmar";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " a classificação.";
        txtTutorial.text += "\r\n\r\n";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " Use o";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " mouse";
        txtTutorial.text += "\r\n";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " para";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " mover";
        yield return new WaitForSeconds(0.2f);
        txtTutorial.text += " a estrela.";
        yield return new WaitForSeconds(0.2f);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    IEnumerator MexeMouse()
    {
        //float rotZ = 15;

        //imgMouse.transform.rotation = new Quaternion(imgMouse.transform.rotation.x, imgMouse.transform.rotation.y, rotZ, imgMouse.transform.rotation.w);
        yield return new WaitForSeconds(0.2f);
            /*for (int x = 0; x < 10; x++) {
            imgMouse.transform.rotation = new Quaternion(imgMouse.transform.rotation.x, imgMouse.transform.rotation.y, imgMouse.transform.rotation.z + 15, imgMouse.transform.rotation.w);
            yield return new WaitForSeconds(0.2f);
            imgMouse.transform.rotation = new Quaternion(imgMouse.transform.rotation.x, imgMouse.transform.rotation.y, imgMouse.transform.rotation.z - 15, imgMouse.transform.rotation.w);
            yield return new WaitForSeconds(0.2f);
            imgMouse.transform.rotation = new Quaternion(imgMouse.transform.rotation.x, imgMouse.transform.rotation.y, imgMouse.transform.rotation.z - 15, imgMouse.transform.rotation.w);
        }*/

    }
}
