//Used for when player interacts with store (old)

using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

    public Canvas MainCanvas, EndCanvas;
    
    void Start () 
    {
        MainCanvas.enabled = true;
        EndCanvas.enabled = false;

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
