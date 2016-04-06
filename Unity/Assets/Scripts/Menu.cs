//Controls application main menu

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour {

    public int retLevel;
    public Canvas MainCanvas;

    void  Start()
    {
        if(PlayerPrefs.GetInt("CurrentLevel") < 7)
        {
            PlayerPrefs.SetInt("CurrentLevel", 7);
        }
        PlayerPrefs.SetInt("ReturnLevel", retLevel);
        PlayerPrefs.Save();
        MainCanvas.enabled = true;
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

    public void LoadCurrent()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadHelp()
    {
        Handheld.PlayFullScreenMovie("menututorial.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

}
