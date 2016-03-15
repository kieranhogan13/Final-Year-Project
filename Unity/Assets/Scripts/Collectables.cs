using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public LevelManager lvlman;
    public int points = 10;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lvlman.AddPoints(points);
            Destroy(this.gameObject);
        }
    }
}
