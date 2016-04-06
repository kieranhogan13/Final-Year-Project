//Controls animation for guess 2 level

using UnityEngine;
using System.Collections;

public class Guess2 : MonoBehaviour {

    public GameObject dog, restart;
    private Vector3 startPos, restartPos;
    public float speed;

    void Start()
    {
        startPos = dog.transform.position;
        restartPos = restart.transform.position;
    }

    void Update()
    {
        dog.transform.position = Vector3.MoveTowards(dog.transform.position, restartPos, speed);
        if (dog.transform.position.y == restartPos.y)
        {
            dog.transform.position = startPos;
        }
    }
}
