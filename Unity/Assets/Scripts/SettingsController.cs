using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour {

    public GameObject SecureSettings;
    public bool ShowSecureSettings;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Awake()
    {
        SecureSettings.SetActive(ShowSecureSettings);
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

}
