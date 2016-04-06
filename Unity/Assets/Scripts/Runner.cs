//Controls character running away

using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
    public Transform target;
    public float speed;
    public float distance = 10f;
    bool facingRight, jumping;
    Animator anim;
    public LevelEnd levelEnd;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        speed = .05f;
        facingRight = true;
    }

    void Update()
    {
        if (transform.position.x > target.position.x && !facingRight || transform.position.x < target.position.x && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
        if(transform.position.x <= target.transform.position.x+10 && jumping == false)
        {
            myBody.AddForce(new Vector2(myBody.velocity.x, 350));
            jumping = true;
        }

        Run();
    }

    void Run()
    {
        Vector3 moveDirection = transform.position - target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, moveDirection, speed);
        anim.SetInteger("State", 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            anim.SetInteger("State", 0);
            jumping = false;
        }
        if (other.gameObject.tag == "Player")
        {
                levelEnd.catches++;
        }
    }
}
