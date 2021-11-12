using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerKeyboardSecnondLevel : SecondSuper
{
    // Start is called before the first frame update
    void Start()
    {
        List<KeyCode> codes = new List<KeyCode>();
        codes.Add(KeyCode.A);
        codes.Add(KeyCode.W);
        codes.Add(KeyCode.S);
        codes.Add(KeyCode.D);
        codes.Add(KeyCode.Space);
        Debug.Log("Keyboard Level 2 Start");
        Starter("Space", KeyCode.Space, codes);
    }

    void Update()
    {
        Debug.Log("Keyboard Update");
        Updater();
    }
}
