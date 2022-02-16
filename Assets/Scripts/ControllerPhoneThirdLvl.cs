using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class ControllerPhoneThirdLvl : ControllerPhoneLvL2
{
    private float rotationY;
    private string orientation;
    private bool updown;
    private bool leftright;
    void Start()
    {
        Starter();
        Input.gyro.enabled = true;
        information.text = "Touch Screen to Start!";
        _inputDevice = "Handheld";
        nextButtonPressEnabled = true;
        touchNeccessary = true;
        DeterminFlick();
    }
    void Update()
    {
        rotationX = Input.gyro.rotationRate.x;
        rotationY = Input.gyro.rotationRate.y;
        if(updown && !touchNeccessary && nextButtonPressEnabled && Mathf.Abs(rotationX) >= 4f)
        {
            PhoneUpdater();
            DeterminFlick();
            StartCoroutine("DelayNextInput");
        }
        if(leftright && !touchNeccessary && nextButtonPressEnabled && Mathf.Abs(rotationY) >= 4f)
        {
            PhoneUpdater();
            DeterminFlick();
            StartCoroutine("DelayNextInput");         
        }
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestPhone3", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        if (touchNeccessary && Input.anyKeyDown && nextButtonPressEnabled)
        {
            PhoneUpdater();
            StartCoroutine("DelayNextInput");
        }
    }
    private void DeterminFlick()
    {
        leftright = false;
        updown = false;
        Random.InitState(System.DateTime.Now.Millisecond);
        switch (Random.Range(0,2))
        {
            case 0:
                OnScreenInfo = "Left or Right";
                leftright = true;
                break;
            case 1:
                OnScreenInfo = "Up or Down";
                updown = true;
                break;
        }
    }
    
}
