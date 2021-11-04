using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ControllerKeyboard : SuperController
{


    void Start()
    {
        Debug.Log("Keyboard Start");
        Starter("Space", KeyCode.Space);
    }

    void Update()
    {
        Debug.Log("Keyboard Update");
        Updater();
    }
}
