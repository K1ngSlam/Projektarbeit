using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ControllerDualshock : SuperController
{
    /*[SerializeField]
    private SpriteRenderer background;
    [SerializeField]
    private Text information;

    private Color red;
    private Color green;

    private float reactionTime, randomDelay, startTime;
    private bool clockisTicking, timerstopable;

    private List<float> reactionTimeAverage;
    private short counter;*/

    void Start()
    {
        Debug.Log("Dualshock Start");
        Starter("X", KeyCode.Joystick1Button1,"Controller");
    }

    void Update()
    {
        Debug.Log("Dualshock Update");
        Updater();
    }
}