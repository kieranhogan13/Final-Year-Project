//Controls level ending, not used currently

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
    public int gameOver, catches;

    void Start ()
    {
        MainCanvas.enabled = true;
        EndCanvas.enabled = false;
        source = GetComponent<AudioSource>();
        gameOver = 0;
    }

	void Update () {
	    if (TimeBar.fillAmount == 0.0f || catches >= 5)
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
