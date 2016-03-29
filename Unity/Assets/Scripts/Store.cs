using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

    public Canvas MainCanvas, EndCanvas;
    
    // Use this for initialization
    void Start () {

        MainCanvas.enabled = true;
        EndCanvas.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            MainCanvas.enabled = false;
            EndCanvas.enabled = true;
        }
    }
}
