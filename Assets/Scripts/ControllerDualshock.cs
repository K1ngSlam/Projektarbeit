using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class ControllerDualshock : SuperController
{
    void Start()
    {
        Debug.Log("Dualshock Start");
        _key_codes.Add(KeyCode.Joystick1Button1);
        Starter(KeyCode.Joystick1Button1,"Gamepad");
        nextButtonPressEnabled = true;
    }

    void Update() 
    {
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestController1", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}