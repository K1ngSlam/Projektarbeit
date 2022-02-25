using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public abstract class SuperController : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer background;
    [SerializeField]
    protected Text information;

    protected string _inputDevice;
    protected Color red;
    protected Color green;

    protected float reactionTime, randomDelay, startTime;
    protected bool clockisTicking, timerstopable, nextButtonPressEnabled, rightInput, Isdone;

    protected List<float> reactionTimeAverage;
    protected short counter;

    protected KeyCode _StartKey;
    protected KeyCode _SearchedKey;
    protected string _SearchedAxisName = "";
    protected float _SearchedAxisValue = 5; //auﬂerhalb der Axis range damit neutral nicht als richtig gewertet wird
    protected List<KeyCode> _key_codes = new List<KeyCode>();
    protected List<string> _axis_codes = new List<string>();
    protected int _has_No_Axis_Flag = 1;



    protected void Starter(KeyCode key, string inputDevice)
    {
        if(_key_codes.Count == 0)
        {
            _key_codes.Add(key);
        }
        _StartKey = key;
        _SearchedKey = key;
        _inputDevice = inputDevice;
        Random.InitState(128381);
        Starter();
    }

    protected void Starter()
    {
        red = new Color(231f / 255f, 24f / 255f, 55f / 255f);
        green = new Color(73f / 255f, 182f / 255f, 117f / 255f);
        background.color = red;
        reactionTime = 0f;
        randomDelay = 0f;
        startTime = 0f;
        information.text = getButtonName() + " to Start!";
        clockisTicking = false;
        timerstopable = false;
        reactionTimeAverage = new List<float>();
        counter = 0;
        Isdone = false;
        Application.targetFrameRate = 144; 
    }

    protected void Updater()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        float AxisValue = 0;
        Debug.Log("before switch");
        if(_SearchedAxisName != "")
        {
            AxisValue = Input.GetAxis(_SearchedAxisName);
        }
        Debug.Log("AfterSwitch");

        rightInput = false;
        if(Input.GetKeyDown(_SearchedKey) || _SearchedAxisValue == AxisValue)
        {
            rightInput = true;
        }

        Debug.Log("SuperController Updater Method");
        if(clockisTicking && !timerstopable)
        {
            StopCoroutine("StartDelay");
            reactionTime = 0f;
            _SearchedKey = _StartKey;
            clockisTicking = false;
            timerstopable = false;
            information.text = "Too soon!!\n" + getButtonName() + " to start again";
            nextButtonPressEnabled = false;
        }
        else if(!rightInput)
        {
            StopCoroutine("StartDelay");
            background.color = red;
            reactionTime = 0f;
            _SearchedKey = _StartKey;
            clockisTicking = false;
            timerstopable = false;
            information.text = "Wrong Input!!\n" + getButtonName() + " to start again";
            nextButtonPressEnabled = false;
        }
        else
        {
            //end result
            if(!clockisTicking && counter == 3)
            {
                information.text = "Test is Over!\n Your Average is: " + reactionTimeAverage.Average().ToString("N3") + "sec";
                background.color = green;
                timerstopable = false;
                if(PlayerPrefs.GetFloat("HighScore") > reactionTimeAverage.Average() || PlayerPrefs.GetFloat("HighScore") == 0)
                {
                    PlayerPrefs.SetFloat("HighScore", reactionTimeAverage.Average());
                    PlayerPrefs.SetString("HighScoreInput", _inputDevice);
                }
                nextButtonPressEnabled = false;
                Isdone = true;
            }
            //screen that tells you to wait for the signal
            else if(!clockisTicking)
            {
                if(Random.Range(0, _has_No_Axis_Flag) == 0)
                {
                    _SearchedAxisName = "";
                    Debug.Log(_key_codes.Count);
                    int random_key_index = Random.Range(0, _key_codes.Count);
                    _SearchedKey = _key_codes[random_key_index];
                }
                else
                {
                    _SearchedKey = KeyCode.None;
                    int random_Axis_Name = Random.Range(0, _axis_codes.Count);
                    int random_Axis_Value = Random.Range(0, 2);
                    _SearchedAxisName = _axis_codes[random_Axis_Name];
                    if(random_Axis_Value == 1)
                    {
                        _SearchedAxisValue = 1;
                    }
                    else
                    {
                        _SearchedAxisValue = -1;
                    }
                }
                StartCoroutine("StartDelay");
                information.text = "Wait for Green!";
                background.color = red;
                clockisTicking = true;
                timerstopable = false;
            }
            //Result of one Test
            else if(clockisTicking && timerstopable)
            {
                StopCoroutine("StartDelay");
                _SearchedKey = _StartKey;
                counter++;
                reactionTime = (Time.time - startTime) - (float)0.007; //0.007 ist die Laufzeit und damit die Zeit unter die man nicht kommen kann. Deshalb abziehen
                reactionTimeAverage.Add(reactionTime);
                if(counter == 3)
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n" + getButtonName() + " to see Average";
                }
                else
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n" + getButtonName() + " to start again";
                }
                clockisTicking = false;
                nextButtonPressEnabled = false;
            }
        }
    }

    protected IEnumerator StartDelay()
    {
        randomDelay = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelay);
        background.color = green;
        information.text = getButtonName() + "!";
        startTime = Time.time;
        clockisTicking = true;
        timerstopable = true;
    }

    protected IEnumerator DelayNextInput()
    {
        yield return new WaitForSeconds(0.5f);
        nextButtonPressEnabled = true;
    }

    protected abstract string getButtonName();
}