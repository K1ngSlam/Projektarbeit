using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ControllerKeyboard : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer background;
    [SerializeField]
    private Text information;
    
    private Color red;
    private Color green;

    private float reactionTime, randomDelay, startTime;
    private bool clockisTicking, timerstopable;

    private List<float> reactionTimeAverage;
    private short counter;

    void Start()
    {
        Debug.Log("Keyboard Start");
        red = new Color(231f / 255f, 24f / 255f, 55f / 255f);
        green = new Color(73f / 255f, 182f / 255f, 117f / 255f);
        background.color = red;
        reactionTime = 0f;
        randomDelay = 0f;
        startTime = 0f;
        information.text = "Press Space to Start!";
        clockisTicking = false;
        timerstopable = false;
        reactionTimeAverage = new List<float>();
        counter = 0;
    }

    void Update()
    {
        Debug.Log("Keyboard Update");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!clockisTicking && counter == 3)
            {
                information.text = "Test is Over!\n Your Average is: " + reactionTimeAverage.Average().ToString("N3") + "sec";
                background.color = green;
                timerstopable = false;
                return;
                //TODO: zurück zur Menue Scene und Speichern des Keyboard Averages
            }
            else if (!clockisTicking)
            {
                StartCoroutine("StartDelay");
                information.text = "Wait for Green!";
                background.color = red;
                clockisTicking = true;
                timerstopable = false;
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
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + "sec\n Press to see Average" ;
                }
                else
                {
                    information.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n Press Space to start again";
                }
                clockisTicking = false;
            }
            else if (clockisTicking && !timerstopable)
            {
                StopCoroutine("StartDelay");
                reactionTime = 0f;
                clockisTicking = false;
                timerstopable = false;
                information.text = "Too soon!!\n Press Space to start again";
            }
        }

    }

    private IEnumerator StartDelay()
    {
        randomDelay = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomDelay);
        background.color = green;
        startTime = Time.time;
        clockisTicking = true;
        timerstopable = true;
    }
}
