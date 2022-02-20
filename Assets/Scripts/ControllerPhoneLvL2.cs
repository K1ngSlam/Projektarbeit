using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ControllerPhoneLvL2 : ControllerPhone
{
    protected float rotationX;
    protected bool touchNeccessary; 
    void Start()
    {
        Starter();
        Input.gyro.enabled = true;
        information.text = "Touch Screen to Start!";
        OnScreenInfo = "Flick the Phone!";
        _inputDevice = "Handheld";
        nextButtonPressEnabled = true;
        touchNeccessary = true;
    }
    void Update()
    {
        rotationX = Input.gyro.rotationRate.x;
        if (!touchNeccessary && Mathf.Abs(rotationX) >= 4f && nextButtonPressEnabled) 
        {
            PhoneUpdater();
            StartCoroutine("DelayNextInput");
        }
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestPhone2", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        if (touchNeccessary && Input.anyKeyDown && nextButtonPressEnabled)
        {
            PhoneUpdater();
            StartCoroutine("DelayNextInput");
        }
    }
    protected void PhoneUpdater()
    {
        if (!clockisTicking && counter == 3) 
        {
            ThirdTestFinished();
            touchNeccessary = true;
        } //Test ist vorbei und es wird die Average Reaktionszeit angezeigt
        else if (clockisTicking && !timerstopable) 
        {
            PressedTooSoon();
            touchNeccessary = true;
        }//Es wurde zu früh reagiert
        else if (!clockisTicking) 
        {
            WaitingForGreen();
            touchNeccessary = false;
        }//Warten auf Grün
        else if (clockisTicking && timerstopable) 
        {
            IsClickableIsStopable();
            touchNeccessary = true;
        }//Mainloop der Test wurde richtig ausgeführt und die Reaktionszeit gespeichert
    }
    protected override string getButtonName()
    {
        throw new System.NotImplementedException();
    }
}
