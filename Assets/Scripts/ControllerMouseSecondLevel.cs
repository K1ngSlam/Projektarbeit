using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class ControllerMouseSecondLevel : AdvancedMouseSuperController
{

    protected bool tempflag;


    public Button buttonAbove, buttonBelow;


    void Update()
    {
        if(Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestMouse2", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if(Input.anyKeyDown && nextButtonPressEnabled) 
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