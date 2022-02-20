using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

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
        Starter(KeyCode.Joystick1Button1, "Gamepad");
        nextButtonPressEnabled = true;

    }
    void Update()
    {
        float AxisValue = 0;
        if(nextButtonPressEnabled)
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");
            float RightStickX = Input.GetAxis("RightStickX");
            float RightStickY = Input.GetAxis("RightStickY");
            if(Math.Abs(Horizontal) > Math.Abs(Vertical))
            {
                AxisValue = Horizontal;
            }
            else if(Math.Abs(Vertical) > Math.Abs(RightStickX))
            {
                AxisValue = Vertical;
            }
            else if(Math.Abs(RightStickX) > Math.Abs(RightStickY))
            {
                AxisValue = RightStickX;
            }
            else
            {
                AxisValue = RightStickY;
            }
        }

        //f  Debug.Log("Keyboard Update");
        //Currently Problem: Only fires if the right axis is activated
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestController3", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        if ((Input.anyKeyDown || Math.Abs(AxisValue) == 1) && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}