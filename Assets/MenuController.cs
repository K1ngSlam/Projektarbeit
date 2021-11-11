using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
