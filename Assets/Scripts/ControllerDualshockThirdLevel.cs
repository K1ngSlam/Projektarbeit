using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ControllerDualshockThirdLevel : SuperController
{
    float Axis_DpadX, Axis_DpadY;
    // Start is called before the first frame update
    void Start()
    {
        _key_codes = new List<KeyCode>();
        _key_codes.Add(KeyCode.Joystick1Button4);
        _key_codes.Add(KeyCode.Joystick1Button5);
        _key_codes.Add(KeyCode.Joystick1Button6);
        _key_codes.Add(KeyCode.Joystick1Button7);
        _axis_codes = new List<string>();
        _axis_codes.Add("Horizontal");
        _axis_codes.Add("Vertical");
        _axis_codes.Add("RightStickX");
        _axis_codes.Add("RightStickY");
        Debug.Log("Dualshock Level 2 Start");
        _has_No_Axis_Flag = 2;
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

        //f  Debug.Log("Keyboard Update");
        //Currently Problem: Only fires if the right axis is activated
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestController3", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        if ((Input.anyKeyDown || AxisValue * AxisValue == 1) && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}