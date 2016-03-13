using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float carSpeed;
    Vector3 position;
    public float minPos = 180;
    public float maxPos = 435;

	// Use this for initialization
	void Start ()
    {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, minPos, maxPos);

        transform.position = position;
	}

    public void LeftButton()
    {
        position.x += (-5 * carSpeed * Time.deltaTime);
        position.x = Mathf.Clamp(position.x, minPos, maxPos);
        transform.position = position;
    }

    public void RightButton()
    {
        position.x += (5 * carSpeed * Time.deltaTime);
        position.x = Mathf.Clamp(position.x, minPos, maxPos);
        transform.position = position;
    }

    public void GoButton()
    {
        carSpeed = 200;
        Ground.speed = 5;
    }

    public void StopButton()
    {
        carSpeed = 0;
        Ground.speed = 0;
    }

}

