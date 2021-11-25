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
        Starter(KeyCode.Joystick1Button1,"Controller");
        nextButtonPressEnabled = true;
    }

    void Update() 
    {
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}