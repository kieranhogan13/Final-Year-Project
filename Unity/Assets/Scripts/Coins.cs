using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour {

    public Canvas MainCanvas, EndCanvas;
    public int score;
    public Image TimeBar;
    public float DecreaseAmount;
    private AudioSource source1, source2;
    public AudioClip collectSound, applause;
    public int gameOver;

    // Use this for initialization
    void Start () {
        MainCanvas.enabled = true;
        EndCanvas.enabled = false;
        DecreaseAmount = 0.2f;
        source1 = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (TimeBar.fillAmount > 0)
        {
            TimeBar.fillAmount -= DecreaseAmount = Time.deltaTime / 15;
        }

        if (TimeBar.fillAmount == 0f)
        {
            print("Game Over");
            this.enabled = false;
            gameOver++;
            if (gameOver == 1)
            {
                MainCanvas.enabled = false;
                EndCanvas.enabled = true;
                source2.PlayOneShot(applause, 1.0f);
            }
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        source1.PlayOneShot(collectSound, 1.0f);
    }

}
