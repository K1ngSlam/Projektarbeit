using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class ControllerKeyboard : SuperController
{
    void Start()
    {
        Debug.Log("Keyboard Start");
        _key_codes.Add(KeyCode.Space);
        Starter(KeyCode.Space, "Keyboard");
        nextButtonPressEnabled = true;
    }

    void Update()
    {
        if(Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestKeyboard1", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if(Input.anyKeyDown && nextButtonPressEnabled)
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
    protected override string getButtonName()
    {
        return "Press " + _SearchedKey.ToString();
    }
}
