using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class ControllerMouseSecondLevel : AdvancedMouseSuperController
{
    [SerializeField]
    protected SpriteRenderer background;
    [SerializeField]
    protected Text information;

    protected string _inputDevice;

    protected Color red;
    protected Color green;

    protected float reactionTime, randomDelay, startTime;
    protected bool clockisTicking, timerstopable, nextButtonPressEnabled, rightInput, Isdone, tempflag;

    protected List<float> reactionTimeAverage;
    protected short counter;

    public Button buttonAbove, buttonBelow, buttonSearched;
    protected KeyCode _StartKey;

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
        _inputDevice = "Mouse";
        tempflag = false;
    }

    void Update()
    {
        if(Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestMouse2", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if(Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }

    protected override void ButtonRandomiser()
    {
        intbuttonSearched = Random.Range(0, 2);
        switch(intbuttonSearched)
        {
            case 0:
                buttonSearched = buttonAbove;
                break;
            case 1:
                buttonSearched = buttonBelow;
                break;
        }
    }
}