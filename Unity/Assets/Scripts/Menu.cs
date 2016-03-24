using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public bool CanMute;

    public bool firstTime;

    void  Start()
    {
        if (firstTime)
        {
            LoadHelp();
            firstTime = false;
        }

        print(PlayerPrefs.GetInt("CurrentLevel"));

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
        CanMute = true;
        
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

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
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

    public void LoadHelp()
    {
        Handheld.PlayFullScreenMovie("test.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

}
