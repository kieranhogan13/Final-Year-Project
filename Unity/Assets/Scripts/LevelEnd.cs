using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    public Canvas MainCanvas, EndCanvas;
    public AudioClip applause;
    private AudioSource source;
    public Image TimeBar;
    public int gameOver;

    // Use this for initialization
    void Start ()
    {
        MainCanvas.enabled = true;
        EndCanvas.enabled = false;
        source = GetComponent<AudioSource>();
        gameOver = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if (TimeBar.fillAmount == 0.0f)
        {
            gameOver++;
            if (gameOver == 1)
            {
                MainCanvas.enabled = false;
                EndCanvas.enabled = true;
                source.PlayOneShot(applause, 1.0f);
            }
        }
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
