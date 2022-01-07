using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class ControllerMouseThirdLevel : AdvancedMouseSuperController
{
   
    public Button buttonNorth, buttonNorthEast, buttonEast, buttonSouthEast, buttonSouth, buttonSouthWest, buttonWest, buttonNorthWest;

    void Update()
    {
        if(Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestMouse3", reactionTimeAverage.Average());
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
        intbuttonSearched = Random.Range(1, 9);
        switch(intbuttonSearched)
        {
            case 1:
                this.buttonSearched = buttonNorth;
                break;
            case 2:
                this.buttonSearched = buttonNorthEast;
                break;
            case 3:
                this.buttonSearched = buttonEast;
                break;
            case 4:
                this.buttonSearched = buttonSouthEast;
                break;
            case 5:
                this.buttonSearched = buttonSouth;
                break;
            case 6:
                this.buttonSearched = buttonSouthWest;
                break;
            case 7:
                this.buttonSearched = buttonWest;
                break;
            case 8:
                this.buttonSearched = buttonNorthWest;
                break;
        }
    }

}
