using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Guess : MonoBehaviour {

    public GameObject[] buttons;
    public Camera cam;
    public GameObject SecureSettings;
    public bool ShowSecureSettings;
    public Canvas MainCanvas, EndCanvas;
    public AudioClip welldone;
    private AudioSource source;

    void Start()
    {
        MainCanvas.enabled = true;
        EndCanvas.enabled = false;
        source = GetComponent<AudioSource>();
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

    public void CorrectAnswer()
    {
        MainCanvas.enabled = false;
        EndCanvas.enabled = true;
        source.PlayOneShot(welldone, 1.0f);
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
