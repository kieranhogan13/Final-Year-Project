//Controls the users player for platform levels

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    bool facingRight, Jumping;
    float speed;
    public float speedY;
    public float speedX;
    public AudioClip bark;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovePlayer(speed);

        JumpFall();

        Turn();
    }


    public void Left()
    {
        speed = -speedX;
    }

    public void Right()
    {
        speed = speedX;
    }

    public void Stop()
    {
        speed = 0;
    }

    public void Jump()
    {
        if (!Jumping)
        {
            Jumping = true;
            body.AddForce(new Vector2(body.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 3);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(bark, vol);
        }
    }

    void Turn()
    {
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    void JumpFall()
    {
        if (Jumping)
        {
            if (rb.velocity.y > 0)
            {
                anim.SetInteger("State", 3);
            }
            else
            {
                anim.SetInteger("State", 1);
            }
        }
    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        if(playerSpeed < 0 && !Jumping || playerSpeed > 0 && !Jumping)
        {
            anim.SetInteger("State", 2);
        }
        if (playerSpeed == 0 && !Jumping)
        {
            anim.SetInteger("State", 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            anim.SetInteger("State", 0);
            Jumping = false;
        }
    }

    public void LoadHelp()
    {
        Handheld.PlayFullScreenMovie("gametutorial.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }
}
