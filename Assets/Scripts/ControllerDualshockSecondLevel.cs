using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ControllerDualshockSecondLevel : SuperController
{
    float Axis_DpadX, Axis_DpadY;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: try wit codes an axis not as parameter but just set

        _key_codes = new List<KeyCode>();
        _key_codes.Add(KeyCode.Joystick1Button0);
        _key_codes.Add(KeyCode.Joystick1Button1);
        _key_codes.Add(KeyCode.Joystick1Button2);
        _key_codes.Add(KeyCode.Joystick1Button3);
        _axis_codes = new List<string>();
        _axis_codes.Add("DpadX");
        _axis_codes.Add("DpadY");
        _has_No_Axis_Flag = 2;
        Debug.Log("Dualshock Level 2 Start");
        Starter(KeyCode.Joystick1Button1, "Dualshock");
        nextButtonPressEnabled = true;
    }
    void Update()
    {
        float AxisValue = 0;

        if(_SearchedAxisName != "")
        {
            AxisValue = Input.GetAxis(this._SearchedAxisName);
        }
        if(Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestController2", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        if((Input.anyKeyDown || AxisValue * AxisValue == 1) && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}