using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDualschockSecondLevel : SuperController
{
    // Start is called before the first frame update
    void Start()
    {
        List<KeyCode> codes = new List<KeyCode>();
        codes.Add(KeyCode.A);
        codes.Add(KeyCode.W);
        codes.Add(KeyCode.S);
        codes.Add(KeyCode.D);
        codes.Add(KeyCode.Space);
        Debug.Log("Keyboard Level 2 Start");
        Starter(KeyCode.Space, codes, "Keyboard");
        nextButtonPressEnabled = true;

    }
    void Update()
    {
        //f  Debug.Log("Keyboard Update");
        if (Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}
