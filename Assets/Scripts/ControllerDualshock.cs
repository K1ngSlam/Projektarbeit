using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ControllerDualshock : SuperController
{
   

    void Start()
    {
        Debug.Log("Dualshock Start");
        Starter(KeyCode.Joystick1Button1);
    }

    void Update()
    {
        Debug.Log("Dualshock Update");
        Updater();
    }
}