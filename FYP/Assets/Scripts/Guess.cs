using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Guess : MonoBehaviour {

    public Canvas MainCanvas;
    public GameObject[] buttons;
    public Camera cam;

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

}
