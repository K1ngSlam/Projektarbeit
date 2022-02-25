using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class ControllerDualshockSecondLevel : SuperController
{
    float Axis_DpadX, Axis_DpadY;
    // Start is called before the first frame update
    void Start()
    {
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
        Starter(KeyCode.Joystick1Button1, "Gamepad");
        nextButtonPressEnabled = true;
    }
    void Update()
    {
        float AxisValue = 0;

        if(nextButtonPressEnabled)
        {
            float DpadXValue = Input.GetAxis("DpadX");
            float DpadYValue = Input.GetAxis("DpadY");
            if(Math.Abs(DpadXValue) > Math.Abs(DpadYValue))
            {
                AxisValue = DpadXValue;
            }
            else
            {
                AxisValue = DpadYValue;
            }
        }
        if(Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestController2", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        if ((Input.anyKeyDown || Math.Abs(AxisValue) == 1) && nextButtonPressEnabled)
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }   
    }
    protected override string getButtonName()
    {
        switch(_SearchedKey)
        {
            case KeyCode.Joystick1Button1:
                return "Press X";
            case KeyCode.Joystick1Button0:
                return "Press Square";
            case KeyCode.Joystick1Button2:
                return "Press O";
            case KeyCode.Joystick1Button3:
                return "Press Triangle";
            case KeyCode.None:
                switch(_SearchedAxisName)
                {
                    case "DpadX":
                        if(_SearchedAxisValue == 1)
                        {
                            return "Press Right";
                        }
                        else
                        {
                            return "Press Left";
                        }
                    case "DpadY":
                        if(_SearchedAxisValue == 1)
                        {
                            return "Press Up";
                        }
                        else
                        {
                            return "Press Down";
                        }
                    default:
                        return "Fehler";
                }
            default:
                return "Press " + _SearchedKey.ToString();
        }
    }
}