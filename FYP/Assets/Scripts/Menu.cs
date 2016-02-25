using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas SettingsCanvas;
    public Scene Game;
    public float hSliderValue = 0.0F;
    public bool CanMute;
    public GameObject[] buttons;

    void Awake()
    {
        SettingsCanvas.enabled = false;
        MainCanvas.enabled = true;
        CanMute = true;
 
        if (buttons == null)
            buttons = GameObject.FindGameObjectsWithTag("Button");

        //Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);

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


    public void ScaleSlider(float f)
    {
        //ExitButton.gameObject.transform.localScale += new Vector3(f, f, f);
        foreach (GameObject button in buttons)
        {
            button.transform.localScale += new Vector3(f, f, f);
        }
    }

    public void ReturnOn()
    {
        SettingsCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene(1);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
