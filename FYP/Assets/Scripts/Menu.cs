using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas, SettingsCanvas;
    public bool CanMute;
    public GameObject[] buttons;
    public Camera cam;

    void Awake()
    {
        SettingsCanvas.enabled = false;
        MainCanvas.enabled = true;
        CanMute = true;
        buttons = GameObject.FindGameObjectsWithTag("Button");

        if(PlayerPrefs.HasKey("bgR"))
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

    public void Mute()
    {
        if (CanMute)
        {
            AudioListener.pause = true;
            CanMute = false;
        }
        else
        {
            AudioListener.pause = false;
            CanMute = true;
        }
    }

    public void SettingsOn()
    {
        SettingsCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

    public void ReturnOn()
    {
        SettingsCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLibrary()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
