using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ControllerPhone : SuperController
{
    void Start()
    {
        Starter();
        information.text = "Touch Screen to Start!";
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
        else if (Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            PhoneUpdater();
            StartCoroutine("DelayNextInput");
        }
    }
    private void PhoneUpdater()
    {
        if (!clockisTicking && counter == 3)
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
        else if (clockisTicking && !timerstopable)
        {
            StopCoroutine("StartPhoneDelay");
            reactionTime = 0f;
            clockisTicking = false;
            timerstopable = false;
            information.text = "Too soon!!\n" + "Press to start again";
            nextButtonPressEnabled = false;
        }
        else if (!clockisTicking)
        {
            StartCoroutine("StartPhoneDelay");
            information.text = "Wait for Green!";
            background.color = red;
            clockisTicking = true;
            timerstopable = false;
        }
        else if (clockisTicking && timerstopable)
        {
            StopCoroutine("StartPhoneDelay");
            counter++;
            reactionTime = Time.time - startTime;
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
    }
    private IEnumerator StartPhoneDelay()
    {
        randomDelay = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelay);
        background.color = green;
        startTime = Time.time;
        clockisTicking = true;
        timerstopable = true;
    }
}