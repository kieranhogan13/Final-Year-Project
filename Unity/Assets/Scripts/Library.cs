using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Library : MonoBehaviour {

    public Canvas MainCanvas;
    public GameObject[] buttons;
    public Camera cam;

    void Start()
    {
        PlayerPrefs.SetInt("ReturnTo", 0);
    }

    void Awake()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");

        if (PlayerPrefs.HasKey("bgR"))
        {
            Color color0 = new Color(PlayerPrefs.GetFloat("bgR"), PlayerPrefs.GetFloat("bgG"), PlayerPrefs.GetFloat("bgB"), 1);
            cam.backgroundColor = color0;
        }
        if (PlayerPrefs.HasKey("btX"))
        {
            foreach (GameObject button in buttons)
            {
                button.transform.localScale = new Vector3(PlayerPrefs.GetFloat("btX"), PlayerPrefs.GetFloat("btY"), 1);
            }
        }
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLibraryActivities()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLibraryGames()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadLibraryMoving()
    {
        SceneManager.LoadScene(6);
    }

}
