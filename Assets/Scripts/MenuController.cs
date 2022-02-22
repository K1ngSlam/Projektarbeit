using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI highscoreInput;
    public TextMeshProUGUI latestMouse1, latestMouse2, latestMouse3, latestKeyboard1, latestKeyboard2, latestKeyboard3, latestController1, latestController2, latestController3, latestHandheld1, latestHandheld2, latestHandheld3;
    public Button mouseTutorialButton, keyboardTutorialButton, keyboardTutorialButtonLevel1, dualshockTutorialButton, Spacebar, handheldTutorialButton;
    public GameObject KeyboardMenuButton, MouseMenuButton, ControllerMenuButton, PhoneMenuButton;
    public static bool bolMouseTutorialShown = false;
    public static bool bolKeyboardTutorialShown = false;
    public static bool bolDualshockTutorialShown = false;
    public static bool bolHandheldTutorialShown = false;


    public void Start()
    {
        Debug.Log("Start Menue Scene");

        if(SystemInfo.deviceType == DeviceType.Handheld)                    //Checkt ob die App auf einem Handheld l�uft und disabled Maus, Tastur, Kontroller optionen
        {
            KeyboardMenuButton = GameObject.Find("KeyboardMenuButton");
            ControllerMenuButton = GameObject.Find("ControllerMenuButton");
            MouseMenuButton = GameObject.Find("MouseMenuButton");
            KeyboardMenuButton.SetActive(false);
            ControllerMenuButton.SetActive(false);
            MouseMenuButton.SetActive(false);
            PhoneMenuButton.SetActive(true);
        }
        latestMouse1.text = "- " + PlayerPrefs.GetFloat("LatestMouse1", 0).ToString("N3") + "ms";
        latestMouse2.text = "- " + PlayerPrefs.GetFloat("LatestMouse2", 0).ToString("N3") + "ms";
        latestMouse3.text = "- " + PlayerPrefs.GetFloat("LatestMouse3", 0).ToString("N3") + "ms";
        latestKeyboard1.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard1", 0).ToString("N3") + "ms";
        latestKeyboard2.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard2", 0).ToString("N3") + "ms";
        latestKeyboard3.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard3", 0).ToString("N3") + "ms";
        latestController1.text = "- " + PlayerPrefs.GetFloat("LatestController1", 0).ToString("N3") + "ms";
        latestController2.text = "- " + PlayerPrefs.GetFloat("LatestController2", 0).ToString("N3") + "ms";
        latestController3.text = "- " + PlayerPrefs.GetFloat("LatestController3", 0).ToString("N3") + "ms";
        latestHandheld1.text = "- " + PlayerPrefs.GetFloat("LatestPhone1", 0).ToString("N3") + "ms";
        latestHandheld2.text = "- " + PlayerPrefs.GetFloat("LatestPhone2", 0).ToString("N3") + "ms";
        latestHandheld3.text = "- " + PlayerPrefs.GetFloat("LatestPhone3", 0).ToString("N3") + "ms";
        highscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("N3") + "ms";
        highscoreInput.text = PlayerPrefs.GetString("HighScoreInput", "");
    }
    public void LoadSceneMouse(int level)
    {
        //TODO:Check for Input avaiable
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("MausScene");
                break;

            case 2:
                SceneManager.LoadScene("MausSecondLevelScene");
                break;

            case 3:
                SceneManager.LoadScene("MouseThirdLevelScene");
                break;

        }
    }
    public void LoadScenePhone(int level)
    {
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("PhoneScene");
                break;

                
            case 2:
                SceneManager.LoadScene("PhoneSecondScene");
                break;

            case 3:
                SceneManager.LoadScene("PhoneThirdScene");
                break;
        }
    }
    public void LoadSceneKeyboard(int level)
    {
        //TODO:Check for Input avaiable
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("KeyboardScene");
                break;

            case 2:
                SceneManager.LoadScene("KeyboardSecondLevel");
                break;

            case 3:
                SceneManager.LoadScene("KeyboardThirdLevel");
                break;
        }
    }
    public void LoadSceneController(int level)
    {
        //TODO:Check for Input avaiable
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("DualshockFirstLevelScene");
                break;

            case 2:
                SceneManager.LoadScene("DualshockSecondLevelScene");
                break;

            case 3:
                SceneManager.LoadScene("DualshockThirdLevelScene");
                break;
        }
    }
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("HighScoreInput");
        PlayerPrefs.DeleteKey("LatestMouse1");
        PlayerPrefs.DeleteKey("LatestMouse2");
        PlayerPrefs.DeleteKey("LatestMouse3");
        PlayerPrefs.DeleteKey("LatestKeyboard1");
        PlayerPrefs.DeleteKey("LatestKeyboard2");
        PlayerPrefs.DeleteKey("LatestKeyboard3");
        PlayerPrefs.DeleteKey("LatestController1");
        PlayerPrefs.DeleteKey("LatestController2");
        PlayerPrefs.DeleteKey("LatestController3");
        PlayerPrefs.DeleteKey("LatestPhone1");
        PlayerPrefs.DeleteKey("LatestPhone2");
        latestMouse1.text = "- " + PlayerPrefs.GetFloat("LatestMouse1", 0).ToString("N3") + "ms";
        latestMouse2.text = "- " + PlayerPrefs.GetFloat("LatestMouse2", 0).ToString("N3") + "ms";
        latestMouse3.text = "- " + PlayerPrefs.GetFloat("LatestMouse3", 0).ToString("N3") + "ms";
        latestKeyboard1.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard1", 0).ToString("N3") + "ms";
        latestKeyboard2.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard2", 0).ToString("N3") + "ms";
        latestKeyboard3.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard3", 0).ToString("N3") + "ms";
        latestController1.text = "- " + PlayerPrefs.GetFloat("LatestController1", 0).ToString("N3") + "ms";
        latestController2.text = "- " + PlayerPrefs.GetFloat("LatestController2", 0).ToString("N3") + "ms";
        latestController3.text = "- " + PlayerPrefs.GetFloat("LatestController3", 0).ToString("N3") + "ms";
        latestHandheld1.text = "- " + PlayerPrefs.GetFloat("LatestPhone1", 0).ToString("N3") + "ms";
        latestHandheld2.text = "- " + PlayerPrefs.GetFloat("LatestPhone2", 0).ToString("N3") + "ms";
        latestHandheld3.text = "- " + PlayerPrefs.GetFloat("LatestPhone3", 0).ToString("N3") + "ms";
        highscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("N3") + "ms";
        highscoreInput.text = PlayerPrefs.GetString("HighScoreInput", "");
    }
    public void OpenTutorialIfNotShown(int tutorialDevice)
    {
        if(!bolMouseTutorialShown && tutorialDevice == 1)
        {
            bolMouseTutorialShown = true;
            mouseTutorialButton.onClick.Invoke();
        }
        if (!bolKeyboardTutorialShown && tutorialDevice == 2)
        {
            bolKeyboardTutorialShown = true;
            keyboardTutorialButton.onClick.Invoke();
        }
        if (!bolDualshockTutorialShown && tutorialDevice == 3)
        {
            bolDualshockTutorialShown = true;
            dualshockTutorialButton.onClick.Invoke();
        }
        if (!bolDualshockTutorialShown && tutorialDevice == 4)
        {
            bolHandheldTutorialShown = true;
            handheldTutorialButton.onClick.Invoke();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}

