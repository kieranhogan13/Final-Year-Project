using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance = 10f; //distance for it to chase

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        speed = .02f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

        //transform.LookAt(target.position); //causes the sphere to chase the player
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self); //corrects the rotation, not clear because object is sphere

        //if (Vector3.Distance(transform.position, target.position) < distance)
        //{
        //    //if the target (in this case player) is within the range of the chaser
        //    //move at specified speed if distance from target is greater than specified distance
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //}
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //The collision that kills the player exists in the enemy class, and 
        //is inherited by the different enemy types Chaser, Xer, and Yer
        if (collision.tag == "Player")
        {

        }
    }
}