using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour {

    public Image TimeBar;
    public float DecreaseAmount;
	
	// Update is called once per frame
	void Update () {
        TimeBar.fillAmount -= DecreaseAmount = Time.deltaTime/10;

        if (TimeBar.fillAmount == 0f)
        {
            print("Game Over");
            this.enabled = false;
        }
	}
}
