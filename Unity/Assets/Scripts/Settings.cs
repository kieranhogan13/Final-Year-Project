//Controls settings functions

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    public Canvas SettingsCanvas;
    public bool CanMute;
    public GameObject[] buttons;
    public Camera cam;

    void Awake()
    {
        CanMute = true;
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

    public void Reset()
    {
        PlayerPrefs.SetInt("CurrentLevel", 7);
        PlayerPrefs.SetInt("ReturnTo", 0);
        PlayerPrefs.Save();
    }

    public void ReturnToLast()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("ReturnTo"));
    }

}
