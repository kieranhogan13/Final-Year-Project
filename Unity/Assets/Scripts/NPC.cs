//Controls secondary character reaction to contact

using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public GameObject speechBubble;
    private SpriteRenderer cat;

    void Start () {
        cat = GetComponent<SpriteRenderer>();
        cat.sortingOrder = 2;
    }
	
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            speechBubble.SetActive(true);
            cat.sortingOrder = 3;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            speechBubble.SetActive(false);
        }
    }
}
