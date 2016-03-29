using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Catcher : MonoBehaviour {

    public Image TimeBar;
    public float DecreaseAmount;
    private AudioSource source;
    public AudioClip meow;
    public bool meowTime;

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        meowTime = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (TimeBar.fillAmount < 0.9f)
        {
            meowTime = true;
        }
        if (TimeBar.fillAmount > 0)
        {
            TimeBar.fillAmount -= DecreaseAmount = Time.deltaTime / 10;
        }

        if (TimeBar.fillAmount == 0f)
        {
            print("Game Over");
            this.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TimeBar.fillAmount = 1;
            if (meowTime)
            {
                source.PlayOneShot(meow, 1.0f);
                meowTime = false;
            }

        }

    }
}
