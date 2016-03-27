using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance = 10f; //distance for it to chase
    bool facingRight;
    Animator anim;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = .05f;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < target.position.x && !facingRight || transform.position.x > target.position.x && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
        anim.SetInteger("State", 1);
        Chase();
        //transform.LookAt(target.position); //causes the sphere to chase the player
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self); //corrects the rotation, not clear because object is sphere

        //if (Vector3.Distance(transform.position, target.position) < distance)
        //{
        //    //if the target (in this case player) is within the range of the chaser
        //    //move at specified speed if distance from target is greater than specified distance
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //}
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        anim.SetInteger("State", 1);
    }

}