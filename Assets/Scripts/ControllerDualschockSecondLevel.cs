using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDualschockSecondLevel : SuperController
{
    float Axis_DpadX, Axis_DpadY;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: try wit codes an axis not as parameter but just set

        List<KeyCode> codes = new List<KeyCode>();
        codes.Add(KeyCode.Joystick1Button0);
        codes.Add(KeyCode.Joystick1Button1);
        codes.Add(KeyCode.Joystick1Button2);
        codes.Add(KeyCode.Joystick1Button3);
        List<string> axis= new List<string>();
        axis.Add("DpadX");
        axis.Add("DpadY");


        Debug.Log("Dualshock Level 2 Start");
        Starter(KeyCode.Joystick1Button1, codes, "Dualshock", axis);
        nextButtonPressEnabled = true;

    }
    void Update()
    {
        float xaxis = Input.GetAxis("DpadX");
        float yaxis = Input.GetAxis("DpadY");

        //f  Debug.Log("Keyboard Update");
        //
        if ((Input.anyKeyDown || xaxis * xaxis == 1 || yaxis * yaxis == 1) && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}