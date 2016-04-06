//Controls collectables

using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public Coins coins;
    public int points;

    void Start () {

	}

	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            coins.AddPoints(points);
            Destroy(this.gameObject);
            Debug.Log("Test");
        }
    }
}
