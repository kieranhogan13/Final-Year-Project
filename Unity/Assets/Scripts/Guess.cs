using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Guess : MonoBehaviour {

    public GameObject[] buttons;
    public Camera cam;
    public GameObject SecureSettings;
    public bool ShowSecureSettings;
    public Canvas MainCanvas, WinCanvas, LoseCanvas;
    public AudioClip welldone;
    private AudioSource source;
    public bool word1, word2, word3, word4, word5;
    public int applause, wrongWordCount;

    void Start()
    {
        MainCanvas.enabled = true;
        WinCanvas.enabled = false;
        LoseCanvas.enabled = false;
        source = GetComponent<AudioSource>();
        word1 = false;
        word2 = false;
        word3 = false;
        word4 = false;
        word5 = false;
        wrongWordCount = 0;
        applause = 0;
    }

    void Awake()
    {
        SecureSettings.SetActive(ShowSecureSettings);
        buttons = GameObject.FindGameObjectsWithTag("Button");
        PlayerPrefs.SetInt("CurrentLevel", 3);
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

    void Update()
    {
        if (word1 && word2 && word3 && word4)
        {
            CorrectAnswer();
        }
        if (wrongWordCount >= 2)
        {
            WrongAnswer();
        }
    }

    void CorrectAnswer()
    {
        MainCanvas.enabled = false;
        WinCanvas.enabled = true;
        PlayerPrefs.SetInt("LevelProgress", 1);
        if (applause == 0)
        {
            source.PlayOneShot(welldone, 1.0f);
            applause ++;
        }
    }

    void WrongAnswer()
    {
        MainCanvas.enabled = false;
        LoseCanvas.enabled = true;
        PlayerPrefs.SetInt("LevelProgress", 0);
        
    }

    public void Word1Button()
    {
        word1 = true;
        word2 = false;
        word3 = false;
        word4 = false;
        word5 = false;
    }
    public void Word2Button()
    {
        word2 = true;
        word3 = false;
        word4 = false;
        word5 = false;
    }
    public void Word3Button()
    {
        word3 = true;
        word4 = false;
        word5 = false;
    }
    public void Word4Button()
    {
        word4 = true;
    }
    public void Word5Button()
    {
        word5 = true;
        wrongWordCount++;
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void NextButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel") + 1);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
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

    public void LoadSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene(0);
    }

}
