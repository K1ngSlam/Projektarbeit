using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ControllerMaus : SuperController
{ 
   
    void Start()
    {
        Debug.Log("Maus Start");
        Starter(KeyCode.Mouse0, "Mouse");
        nextButtonPressEnabled = true;
    }

    void Update()
    {
        Debug.Log("Maus Update");
        if (Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}