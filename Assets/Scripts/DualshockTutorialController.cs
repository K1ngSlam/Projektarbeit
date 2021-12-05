using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DualshockTutorialController : MonoBehaviour
{
    public Image ImageLvl1, ImageLvl2, ImageLvl3;
    public Button ButtonLvl1, ButtonLvl2, ButtonLvl3;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Level1()
    {
        ButtonLvl1.image.color = Color.green;
        ButtonLvl2.image.color = Color.white;
        ButtonLvl3.image.color = Color.white;
        ImageLvl1.gameObject.SetActive(true);
        ImageLvl2.gameObject.SetActive(false);
        ImageLvl3.gameObject.SetActive(false);
    }
    public void Level2()
    {
        ButtonLvl1.image.color = Color.white;
        ButtonLvl2.image.color = Color.green;
        ButtonLvl3.image.color = Color.white;
        ImageLvl1.gameObject.SetActive(false);
        ImageLvl2.gameObject.SetActive(true);
        ImageLvl3.gameObject.SetActive(false);
    }
    public void Level3()
    {
        ButtonLvl1.image.color = Color.white;
        ButtonLvl2.image.color = Color.white;
        ButtonLvl3.image.color = Color.green;
        ImageLvl1.gameObject.SetActive(false);
        ImageLvl2.gameObject.SetActive(false);
        ImageLvl3.gameObject.SetActive(true);
    }
    public void ReturnToLevelSelect()
    {
        ButtonLvl1.image.color = Color.white;
        ButtonLvl2.image.color = Color.white;
        ButtonLvl3.image.color = Color.white;
        ImageLvl1.gameObject.SetActive(false);
        ImageLvl2.gameObject.SetActive(false);
        ImageLvl3.gameObject.SetActive(false);
    }
}
