using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerDualshockThirdLevel : SuperController
{
    float Axis_DpadX, Axis_DpadY;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: try wit codes an axis not as parameter but just set
        List<KeyCode> codes = new List<KeyCode>();
        codes.Add(KeyCode.Joystick1Button4);
        codes.Add(KeyCode.Joystick1Button5);
        codes.Add(KeyCode.Joystick1Button6);
        codes.Add(KeyCode.Joystick1Button7);
        List<string> axis = new List<string>();
        axis.Add("Horizontal");
        axis.Add("Vertical");
        axis.Add("RightStickX");
        axis.Add("RightStickY");
        Debug.Log("Dualshock Level 2 Start");
        Starter(KeyCode.Joystick1Button1, codes, "Dualshock", axis);
        nextButtonPressEnabled = true;

    }
    void Update()
    {
        float AxisValue = 0;
        
        if(_SearchedAxisName != "")
        {
            AxisValue = Input.GetAxis(this._SearchedAxisName);
        }

        //f  Debug.Log("Keyboard Update");
        //Currently Problem: Only fires if the right axis is activated
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            SceneManager.LoadScene("Main Menu");
        }
        if ((Input.anyKeyDown || AxisValue * AxisValue == 1) && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}