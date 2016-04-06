//Animates library character

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LibAnimation : MonoBehaviour
{
    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    public void Run()
    {
        anim.SetInteger("State", 2);
    }

    public void Walk()
    {
        anim.SetInteger("State", 1);
    }

    public void Dance()
    {
        anim.SetInteger("State", 3);
    }

    public void LibraryReturn()
    {
        SceneManager.LoadScene(3);
    }
}
