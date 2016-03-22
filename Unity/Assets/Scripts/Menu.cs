using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public bool CanMute;
    public GameObject[] buttons;
    public Camera cam;
    public GameObject SecureSettings;
    public bool ShowSecureSettings;

    void  Start()
    {
        print(PlayerPrefs.GetInt("CurrentLevel"));
;       Handheld.PlayFullScreenMovie("test.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);

        if (PlayerPrefs.GetInt("CurrentLevel") < 7 || PlayerPrefs.GetInt("CurrentLevel") > 8)
        {
            PlayerPrefs.SetInt("CurrentLevel", 7);
            print("test");
        }
        PlayerPrefs.SetInt("ReturnTo", 0);
        PlayerPrefs.Save();
    }

    void Awake()
    {    
        MainCanvas.enabled = true;
        SecureSettings.SetActive(ShowSecureSettings);

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

    public void ShowSettingsSecure()
    {
        ShowSecureSettings = !ShowSecureSettings;
        SecureSettings.SetActive(ShowSecureSettings);
    }
    public void HideSettingsSecure()
    {
        ShowSecureSettings = false;
        SecureSettings.SetActive(ShowSecureSettings);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadChoose()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLibrary()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadGuess()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
