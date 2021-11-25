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
    public void Start()
    {
        Debug.Log("Start Menue Scene");
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
        switch (level)
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
}
