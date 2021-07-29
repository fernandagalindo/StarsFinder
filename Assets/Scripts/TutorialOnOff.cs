using UnityEngine.UI;
using UnityEngine;

public class TutorialOnOff: MonoBehaviour
{
    public Toggle tutorialOnOff;
    private void Start()
    {
        tutorialOnOff = GetComponent<Toggle>();
        if (StaticVar.tutorialOn)
        {
            tutorialOnOff.isOn = true;
        } else
        {
            tutorialOnOff.isOn = false;
        }
        Debug.Log(StaticVar.tutorialOn);
    }


    public void turnOnOff()
    {
        if (tutorialOnOff.isOn)
        {
            StaticVar.tutorialOn = true;
        }
        else
        {
            StaticVar.tutorialOn = false;
        }
    }
}
