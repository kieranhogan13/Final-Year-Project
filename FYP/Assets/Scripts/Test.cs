using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public string scene;

    void Start()
    {

    }

    void OnGUI()
    {
        if (GUI.Button (new Rect (0,0,100,30), "Start"))
        {
            Initiate.Fade(scene, Color.blue, 0.5f);
        }
    }
}
