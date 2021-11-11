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
        Starter("", KeyCode.Mouse0);
    }

    void Update()
    {
        Debug.Log("Maus Update");
        Updater();
    }
}