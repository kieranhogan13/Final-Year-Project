//Controls character chasing

using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance = 10f;
    bool facingRight;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        speed = .05f;
        facingRight = true;
    }

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
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        anim.SetInteger("State", 1);
    }

}