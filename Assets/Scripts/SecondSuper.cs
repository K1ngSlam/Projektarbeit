using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SecondSuper : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer background;
    [SerializeField]
    protected Text information;

    protected Color red;
    protected Color green;

    protected float reactionTime, randomDelay, startTime;
    protected bool clockisTicking, timerstopable;

    protected List<float> reactionTimeAverage;
    protected short counter;

    protected string _StarterButtonName;
    protected KeyCode _StartKey;
    protected KeyCode _SearchedKey;
    protected List<KeyCode> _codes;


    protected void Starter(string StarterButtonName, KeyCode key, List<KeyCode> codes)
    {
        _StartKey = key;
        if (!StarterButtonName.Equals(""))
        {
            _StarterButtonName = StarterButtonName + " ";
        }
        red = new Color(231f / 255f, 24f / 255f, 55f / 255f);
        green = new Color(73f / 255f, 182f / 255f, 117f / 255f);
        background.color = red;
        _codes = codes;
        int random_key_index = Random.Range(0, codes.Count);
        _SearchedKey = codes[random_key_index];


        reactionTime = 0f;
        randomDelay = 0f;
        startTime = 0f;
        information.text = "Press " + _StarterButtonName + "to Start!";
        clockisTicking = false;
        timerstopable = false;
        reactionTimeAverage = new List<float>();
        counter = 0;
    }

    protected void Updater()
    {
        if (Input.GetKeyDown(_StartKey))
        {
            if (!clockisTicking && counter == 3)
            {
                information.text = "Test is Over!\n Your Average is: " + reactionTimeAverage.Average().ToString("N3") + "sec";
                background.color = green;
                timerstopable = false;
                SceneManager.LoadScene("Main Menu"); //Zu ladende Scene einfach hier rein
                //TODO:Speichern des Averages
            }
            else if (!clockisTicking)
            {
                int random_key_index = Random.Range(0, _codes.Count);
                _SearchedKey = _codes[random_key_index];
                StartCoroutine("StartDelay");
                information.text = "Wait for Green!";
                background.color = red;
                clockisTicking = true;
                timerstopable = false;
            }
            else if (clockisTicking && timerstopable)
            {
                StopCoroutine("StartDelay");
                int random_key_index = Random.Range(0, _codes.Count);
                _SearchedKey = _codes[random_key_index];
                counter++;
                Debug.Log(counter);
                reactionTime = Time.time - startTime;
                reactionTimeAverage.Add(reactionTime);
                if (counter == 3)
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n Press to see Average";
                }
                else
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n Press " + _StarterButtonName + "to start again";
                }
                clockisTicking = false;
            }
            else if (clockisTicking && !timerstopable)
            {
                StopCoroutine("StartDelay");
                reactionTime = 0f;
                clockisTicking = false;
                timerstopable = false;
                information.text = "Too soon!!\n Press " + _StarterButtonName + "to start again";
            }
        }

        if (Input.GetKeyDown(_SearchedKey))
        {
            if (!clockisTicking && counter == 3)
            {
                information.text = "Test is Over!\n Your Average is: " + reactionTimeAverage.Average().ToString("N3") + "sec";
                background.color = green;
                timerstopable = false;
                SceneManager.LoadScene("Main Menu"); //Zu ladende Scene einfach hier rein
                //TODO:Speichern des Averages
            }
            
            else if (clockisTicking && timerstopable)
            {
                StopCoroutine("StartDelay");
                counter++;
                Debug.Log(counter);
                reactionTime = Time.time - startTime;
                reactionTimeAverage.Add(reactionTime);
                if (counter == 3)
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n Press to see Average";
                }
                else
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n Press " + _StarterButtonName + "to start again";
                }
                clockisTicking = false;
            }
            else if (clockisTicking && !timerstopable)
            {
                StopCoroutine("StartDelay");
                reactionTime = 0f;
                clockisTicking = false;
                timerstopable = false;
                information.text = "Too soon!!\n Press " + _StarterButtonName + "to start again";
            }
        }

    }



    protected IEnumerator StartDelay()
    {
        randomDelay = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelay);
        background.color = green;
        information.text = "Press " + _SearchedKey.ToString() +"!";
        startTime = Time.time;
        clockisTicking = true;
        timerstopable = true;
    }
}
