using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    bool facingRight, Jumping;
    float speed;
    public float jumpSpeedY;
    public float speedX;
    public AudioClip bark;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        source = GetComponent<AudioSource>();
        print(PlayerPrefs.GetInt("CurrentLevel"));
        //PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetInteger("State", 1);
        MovePlayer(speed);
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!Jumping)
            {
                Jumping = true;
                rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
                anim.SetInteger("State", 3);
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(bark, vol);
            }
        }

        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
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
            Jumping = false;
            anim.SetInteger("State", 0);
        }
    }

    public void WalkLeft()
    {
        speed = -speedX;
    }

    public void WalkRight()
    {
        speed = speedX;
    }

    public void StopMoving()
    {
        speed = 0;
    }

    public void Jump()
    {
        if (!Jumping)
        {
            Jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 3);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(bark, vol);
        }
    }
}
