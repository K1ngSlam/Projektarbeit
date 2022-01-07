using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;


public abstract class AdvancedMouseSuperController : MonoBehaviour
{

    [SerializeField]
    protected SpriteRenderer background;
    [SerializeField]
    protected Text information;

    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    protected string _inputDevice;

    protected Color red;
    protected Color green;

    protected float reactionTime, randomDelay, startTime;
    protected bool clockisTicking, timerstopable, nextButtonPressEnabled, rightInput, Isdone, isHoverOverRightSpot;

    protected List<float> reactionTimeAverage;
    protected short counter;

    public Button buttonSearched;
    public int intbuttonSearched;

    protected KeyCode _StartKey;
    // Start is called before the first frame update
    void Start()
    {
        nextButtonPressEnabled = true;
        Debug.Log("Maus Start");
        red = new Color(231f / 255f, 24f / 255f, 55f / 255f);
        green = new Color(73f / 255f, 182f / 255f, 117f / 255f);
        background.color = red;
        reactionTime = 0f;
        randomDelay = 0f;
        startTime = 0f;
        information.text = "Click to Start!";
        clockisTicking = false;
        timerstopable = false;
        reactionTimeAverage = new List<float>();
        counter = 0;
        Isdone = false;
        _inputDevice = "mouse";
        isHoverOverRightSpot = false;
    }


    protected void Updater()
    {
        Debug.Log("SuperController Updater Method");
        if(clockisTicking && !timerstopable)
        {
            StopCoroutine("StartDelay");
            reactionTime = 0f;
            clockisTicking = false;
            timerstopable = false;
            information.text = "Too soon!!\n" + "Click to start again";
            nextButtonPressEnabled = false;
            isHoverOverRightSpot = false;
        }
        else if(Input.anyKeyDown || isHoverOverRightSpot)
        {
            Debug.Log("Is clock Ticking:" + clockisTicking);
            Debug.Log(counter);

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
            else if(!clockisTicking)
            {
                ButtonRandomiser();
                Debug.Log("intbuttonSearched:" + intbuttonSearched);
                StartCoroutine("StartDelay");
                information.text = "Wait for Green!";
                background.color = red;
                clockisTicking = true;
                timerstopable = false;

            }
            else if(clockisTicking && timerstopable && isHoverOverRightSpot)
            {
                StopCoroutine("StartDelay");
                buttonSearched.image.enabled = false;
                counter++;
                reactionTime = Time.time - startTime;
                reactionTimeAverage.Add(reactionTime);
                if(counter == 3)
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n" + "Click to see Average";
                    Debug.Log("counter:" + counter);
                }
                else
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n" + "Click to start again";
                }
                isHoverOverRightSpot = false;
                clockisTicking = false;
                nextButtonPressEnabled = true;
            }
        }
    }
    public void buttonCaller(int i)
    {
        if(intbuttonSearched == i)
        {
            isHoverOverRightSpot = true;
            Updater();
        }
    }

    protected abstract void ButtonRandomiser();

    protected IEnumerator StartDelay()
    {
        randomDelay = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelay);
        background.color = green;
        information.text = "Now!";
        buttonSearched.image.enabled = true;
        startTime = Time.time;
        clockisTicking = true;
        timerstopable = true;
    }

    protected IEnumerator DelayNextInput()
    {
        yield return new WaitForSeconds(0.5f);
        nextButtonPressEnabled = true;
    }

}
