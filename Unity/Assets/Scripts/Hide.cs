﻿using UnityEngine;
using System.Collections;

public class Hide : MonoBehaviour {

    public Canvas MainCanvas, EndCanvas;
    public GameObject cat1, cat2, cat3;

    // Use this for initialization
    void Start () {
        MainCanvas.enabled = true;
        EndCanvas.enabled = false;
        cat1.GetComponent<SpriteRenderer>();
        cat2.GetComponent<SpriteRenderer>();
        cat3.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (cat1.GetComponent<SpriteRenderer>().sortingOrder == 3 && cat2.GetComponent<SpriteRenderer>().sortingOrder == 3 && cat3.GetComponent<SpriteRenderer>().sortingOrder == 3)
        {
            Debug.Log("test");
            MainCanvas.enabled = false;
            EndCanvas.enabled = true;
        }

    }
}
