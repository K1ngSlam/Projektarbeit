using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class ControllerMaus : SuperController
{

    void Start()
    {
        Debug.Log("Maus Start");
        _key_codes.Add(KeyCode.Mouse0);
        Starter(KeyCode.Mouse0, "Mouse");
        nextButtonPressEnabled = true;
    }

    void Update()
    {
        if(Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestMouse1", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.anyKeyDown && nextButtonPressEnabled)
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
    protected override string getButtonName()
    {
        return "Click";
    }
}