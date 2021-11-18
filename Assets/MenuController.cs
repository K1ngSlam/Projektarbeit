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
    public void LoadSceneKeyboard()
    {
        //TODO:Check for Input avaiable
        SceneManager.LoadScene("KeyboardScene");
    }
    public void LoadSceneController()
    {
        //TODO:Check for Input avaiable
        SceneManager.LoadScene("DualshockScene");
    }
}
