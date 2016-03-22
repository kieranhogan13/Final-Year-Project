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
    public GUITexture overlay;
    public float fadeTime;

    void  Start()
    {
        Handheld.PlayFullScreenMovie("test.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

    void Awake()
    {    
        MainCanvas.enabled = false;
        overlay.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        StartCoroutine(FadeToClear());
        SecureSettings.SetActive(ShowSecureSettings);

        CanMute = true;
        buttons = GameObject.FindGameObjectsWithTag("Button");
        
        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.Save();

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

    private IEnumerator FadeToClear()
    {
        overlay.gameObject.SetActive(true);
        overlay.color = Color.black;
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;

        while(progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.black, Color.clear, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
        overlay.color = Color.clear;
        overlay.gameObject.SetActive(false);
        MainCanvas.enabled = true;
    }

    private IEnumerator FadeToBlack()
    {
        overlay.gameObject.SetActive(true);
        overlay.color = Color.clear;
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
        overlay.color = Color.black;
        MainCanvas.enabled = false;
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

    public void LoadGuess()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLibrary()
    {
        SceneManager.LoadScene(6);
    }

    public void DBTest()
    {
        SceneManager.LoadScene(7);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
