using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ControllerPhone : SuperController
{
    protected string OnScreenInfo;
    void Start()
    {
        Starter();
        information.text = "Touch Screen to Start!";
        OnScreenInfo = "Touch the screen!";
        _inputDevice = "Handheld";
        nextButtonPressEnabled = true;
    }
    void Update()
    {
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestPhone1", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.anyKeyDown && nextButtonPressEnabled)
        {
            PhoneUpdater();
            StartCoroutine("DelayNextInput");
        }
    }
    private void PhoneUpdater()
    {
        if (!clockisTicking && counter == 3)
        {
            ThirdTestFinished();
        }
        else if (clockisTicking && !timerstopable)
        {
            PressedTooSoon();
        }
        else if (!clockisTicking)
        {
            WaitingForGreen();
        }
        else if (clockisTicking && timerstopable)
        {
            IsClickableIsStopable();
        }
    }
    private IEnumerator StartPhoneDelay()
    {
        randomDelay = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelay);
        background.color = green;
        information.text = OnScreenInfo;
        startTime = Time.time;
        clockisTicking = true;
        timerstopable = true;
    }
    protected void ThirdTestFinished()
    {
        information.text = "Test is Over!\n Your Average is: " + reactionTimeAverage.Average().ToString("N3") + "sec";
        background.color = green;
        timerstopable = false;
        if (PlayerPrefs.GetFloat("HighScore") > reactionTimeAverage.Average() || PlayerPrefs.GetFloat("HighScore") == 0)
        {
            PlayerPrefs.SetFloat("HighScore", reactionTimeAverage.Average());
            PlayerPrefs.SetString("HighScoreInput", _inputDevice);
        }
        nextButtonPressEnabled = false;
        Isdone = true;
    }
    protected void PressedTooSoon()
    {
        StopCoroutine("StartPhoneDelay");
        reactionTime = 0f;
        clockisTicking = false;
        timerstopable = false;
        information.text = "Too soon!!\n" + "Press to start again";
        nextButtonPressEnabled = false;
    }
    protected void WaitingForGreen()
    {
        StartCoroutine("StartPhoneDelay");
        information.text = "Wait for Green!";
        background.color = red;
        clockisTicking = true;
        timerstopable = false;
    }
    protected void IsClickableIsStopable()
    {
        StopCoroutine("StartPhoneDelay");
        counter++;
        reactionTime = (Time.time - startTime) - (float)0.007;
        reactionTimeAverage.Add(reactionTime);
        if (counter == 3)
        {
            information.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n" + "Press again to see Average";
        }
        else
        {
            information.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n" + "Press to start again";
        }
        clockisTicking = false;
        nextButtonPressEnabled = false;
    }
    protected override string getButtonName()
    {
        throw new System.NotImplementedException();
    }
}
