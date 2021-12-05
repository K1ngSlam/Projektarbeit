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
    public TextMeshProUGUI latestMouse1, latestKeyboard1, latestKeyboard2, latestKeyboard3, latestController1, latestController2, latestController3;
    public Button mouseTutorialButton, keyboardTutorialButton, keyboardTutorialButtonLevel1, dualshockTutorialButton, Spacebar;
    public void Start()
    {
        Debug.Log("Start Menue Scene");

        PlayerPrefs.SetInt("MouseTurorial", 0);
        PlayerPrefs.SetInt("KeyboardTurorial", 0);
        PlayerPrefs.SetInt("DualshokTurorial", 0);

        latestMouse1.text = "- " + PlayerPrefs.GetFloat("LatestMouse1", 0).ToString("N3") + "ms";
        latestKeyboard1.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard1", 0).ToString("N3") + "ms";
        latestKeyboard2.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard2", 0).ToString("N3") + "ms";
        latestKeyboard3.text = "- " + PlayerPrefs.GetFloat("LatestKeyboard3", 0).ToString("N3") + "ms";
        latestController1.text = "- " + PlayerPrefs.GetFloat("LatestController1", 0).ToString("N3") + "ms";
        latestController2.text = "- " + PlayerPrefs.GetFloat("LatestController2", 0).ToString("N3") + "ms";
        latestController3.text = "- " + PlayerPrefs.GetFloat("LatestController3", 0).ToString("N3") + "ms";
        highscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("N3") + "ms";
        highscoreInput.text = PlayerPrefs.GetString("HighScoreInput", "");
    }
    public void LoadSceneMouse()
    {
        //TODO:Check for Input avaiable
        SceneManager.LoadScene("MausScene");
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
        PlayerPrefs.DeleteAll();
        highscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("N3") + "ms";
        highscoreInput.text = PlayerPrefs.GetString("HighScoreInput", "");
    }
    public void MouseMenu()
    {
        if(PlayerPrefs.GetInt("MouseTurorial") == 0)
        {
            PlayerPrefs.SetInt("MouseTurorial", 1);
            mouseTutorialButton.onClick.Invoke();
        }
    }
    public void KeyboardMenu()
    {
        if(PlayerPrefs.GetInt("KeyboardTurorial") == 0)
        {
            PlayerPrefs.SetInt("KeyboardTurorial", 1);
            Debug.Log("keyboardmenu");
            keyboardTutorialButton.onClick.Invoke();
        }
    }
    public void DualshockMenu()
    {
        if(PlayerPrefs.GetInt("DualshokTurorial") == 0)
        {
            PlayerPrefs.SetInt("DualshokTurorial", 1);
            dualshockTutorialButton.onClick.Invoke();
        }
    }
    public void KeyboardTutorialLvl1()
    {
        Spacebar.image.color = Color.green;
    }
}
