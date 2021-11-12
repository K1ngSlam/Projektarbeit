using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SuperController : MonoBehaviour
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

    protected KeyCode _StartKey;
    protected KeyCode _SearchedKey;
    protected List<KeyCode> _key_codes = new List<KeyCode>();


    protected void Starter(KeyCode key, string str)
    {
        if (_key_codes.Count == 0)
        {
            _key_codes.Add(key);
        }
        _StartKey = key;
        _SearchedKey = key;
        Starter();
    }
    protected void Starter(KeyCode key, List<KeyCode> codes)
    {
        _key_codes = codes;
        Starter(key);
    }
    protected void Starter(KeyCode key)
    {
        if (_key_codes.Count == 0)
        {
            _key_codes.Add(key);
        }
        _StartKey = key;
        _SearchedKey = key;
        Starter();
    }
    protected void Starter()
    {
        red = new Color(231f / 255f, 24f / 255f, 55f / 255f);
        green = new Color(73f / 255f, 182f / 255f, 117f / 255f);
        background.color = red;
        reactionTime = 0f;
        randomDelay = 0f;
        startTime = 0f;
        information.text = getButtonName() + " to Start!";
        clockisTicking = false;
        timerstopable = false;
        reactionTimeAverage = new List<float>();
        counter = 0;
    }

    protected void Updater()
    {
        if (Input.anyKeyDown && clockisTicking && !timerstopable)
        {
            StopCoroutine("StartDelay");
            reactionTime = 0f;
            _SearchedKey = _StartKey;
            clockisTicking = false;
            timerstopable = false;
            information.text = "Too soon!!\n" + getButtonName() + " to start again";
        }
        else if (Input.GetKeyDown(_SearchedKey))
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
                /* I could move this section into its own method, and make two versions of the method to make sure that
                 * the randomizer isn't called when there's only one Key in the _key_codes list. However, the call of random
                 * and new asignement of _SearchedKey should not cost enough processing power to make that change worth the effort,
                 * especially since the time saved there would likely be consumed by the neccessary if-clause 
                 * used to determine the right method to call.
                 */
                int random_key_index = Random.Range(0, _key_codes.Count);
                _SearchedKey = _key_codes[random_key_index];
                StartCoroutine("StartDelay");
                information.text = "Wait for Green!";
                background.color = red;
                clockisTicking = true;
                timerstopable = false;
            }
            else if (clockisTicking && timerstopable)
            {
                StopCoroutine("StartDelay");
                _SearchedKey = _StartKey;
                counter++;
                // Debug.Log(counter);
                reactionTime = Time.time - startTime;
                reactionTimeAverage.Add(reactionTime);
                if (counter == 3)
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n" + getButtonName() + " to see Average";
                }
                else
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n" + getButtonName() + " to start again";
                }
                clockisTicking = false;
            }
        }
    }

    private string getButtonName()
    {
        if (_SearchedKey.ToString().Equals("Mouse0"))
        {
            return "Klick";
        }
        if (_SearchedKey == KeyCode.Joystick1Button1)
        {
            return "Press X";
        }
        return "Press " + _SearchedKey.ToString();

    }


    protected IEnumerator StartDelay()
    {
        randomDelay = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelay);
        background.color = green;
        information.text = getButtonName() + "!";
        startTime = Time.time;
        clockisTicking = true;
        timerstopable = true;
    }
}