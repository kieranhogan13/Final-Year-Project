//Controls settings accesss security button

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour {

    public GameObject SecureSettings;
    public bool ShowSecureSettings;

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
