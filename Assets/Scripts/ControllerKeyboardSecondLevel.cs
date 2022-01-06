using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ControllerKeyboardSecondLevel : SuperController
{
    // Start is called before the first frame update
    void Start()
    {
        _key_codes = new List<KeyCode>();
        _key_codes.Add(KeyCode.A);
        _key_codes.Add(KeyCode.W);
        _key_codes.Add(KeyCode.S);
        _key_codes.Add(KeyCode.D);
        _key_codes.Add(KeyCode.Space);
        Debug.Log("Keyboard Level 2 Start");
     
        Starter(KeyCode.Space, "Keyboard");
        nextButtonPressEnabled = true;
    }

    void Update()
    {
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestKeyboard2", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}
