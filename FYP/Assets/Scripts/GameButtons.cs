﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MenuReturn()
    {
        SceneManager.LoadScene(0);
    }
}
