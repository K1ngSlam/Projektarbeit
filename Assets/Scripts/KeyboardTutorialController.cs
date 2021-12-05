using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class KeyboardTutorialController : MonoBehaviour
{
    public Button keyboardTutorialButtonLevel1, keyboardTutorialButtonLevel2, keyboardTutorialButtonLevel3,
        Spacebar, WKeyButton, AKeyButton, DKeyButton, SKeyButton, LeftArrowButton, RightArrowButton, UpArrowButton, DownArrowButton;
    // Start is called before the first frame update
    void Start()
    {
        keyboardTutorialButtonLevel1.image.color = Color.white;
        keyboardTutorialButtonLevel2.image.color = Color.white;
        keyboardTutorialButtonLevel3.image.color = Color.white;
        Spacebar.image.color = Color.white;
        WKeyButton.image.color = Color.white;
        AKeyButton.image.color = Color.white;
        DKeyButton.image.color = Color.white;
        SKeyButton.image.color = Color.white;
        LeftArrowButton.image.color = Color.white;
        RightArrowButton.image.color = Color.white;
        UpArrowButton.image.color = Color.white;
        DownArrowButton.image.color = Color.white;
    }
    public void level1()
    {
        keyboardTutorialButtonLevel1.image.color = Color.green;
        keyboardTutorialButtonLevel2.image.color = Color.white;
        keyboardTutorialButtonLevel3.image.color = Color.white;
        Spacebar.image.color = Color.green;
        WKeyButton.image.color = Color.white;
        AKeyButton.image.color = Color.white;
        DKeyButton.image.color = Color.white;
        SKeyButton.image.color = Color.white;
        LeftArrowButton.image.color = Color.white;
        RightArrowButton.image.color = Color.white;
        UpArrowButton.image.color = Color.white;
        DownArrowButton.image.color = Color.white;
    }
    public void level2()
    {
        keyboardTutorialButtonLevel1.image.color = Color.white;
        keyboardTutorialButtonLevel2.image.color = Color.green;
        keyboardTutorialButtonLevel3.image.color = Color.white;
        Spacebar.image.color = Color.green;
        WKeyButton.image.color = Color.green;
        AKeyButton.image.color = Color.green;
        DKeyButton.image.color = Color.green;
        SKeyButton.image.color = Color.green;
        LeftArrowButton.image.color = Color.white;
        RightArrowButton.image.color = Color.white;
        UpArrowButton.image.color = Color.white;
        DownArrowButton.image.color = Color.white;
    }
    public void level3()
    {
        keyboardTutorialButtonLevel1.image.color = Color.white;
        keyboardTutorialButtonLevel2.image.color = Color.white;
        keyboardTutorialButtonLevel3.image.color = Color.green;
        Spacebar.image.color = Color.green;
        WKeyButton.image.color = Color.green;
        AKeyButton.image.color = Color.green;
        DKeyButton.image.color = Color.green;
        SKeyButton.image.color = Color.green;
        LeftArrowButton.image.color = Color.green;
        RightArrowButton.image.color = Color.green;
        UpArrowButton.image.color = Color.green;
        DownArrowButton.image.color = Color.green;
    }
    public void ReturnToLvlSelection()
    {
        keyboardTutorialButtonLevel1.image.color = Color.white;
        keyboardTutorialButtonLevel2.image.color = Color.white;
        keyboardTutorialButtonLevel3.image.color = Color.white;
        Spacebar.image.color = Color.white;
        WKeyButton.image.color = Color.white;
        AKeyButton.image.color = Color.white;
        DKeyButton.image.color = Color.white;
        SKeyButton.image.color = Color.white;
        LeftArrowButton.image.color = Color.white;
        RightArrowButton.image.color = Color.white;
        UpArrowButton.image.color = Color.white;
        DownArrowButton.image.color = Color.white;
    }
}