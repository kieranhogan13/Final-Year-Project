using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public Canvas MainCanvas, EndCanvas;
    public AudioClip applause;
    private AudioSource source;

    // Use this for initialization
    void Start () {

        MainCanvas.enabled = true;
        EndCanvas.enabled = false;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            {
                MainCanvas.enabled = false;
                EndCanvas.enabled = true;
                source.PlayOneShot(applause, 1.0f);
            }
        }
    }
}
