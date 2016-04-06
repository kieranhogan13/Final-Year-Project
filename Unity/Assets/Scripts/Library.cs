//Controls library category selection

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Library : MonoBehaviour
{
    public Canvas MainCanvas;
    public GameObject[] buttons;
    public Camera cam;
    public int retLevel;

    void Start()
    {
        PlayerPrefs.SetInt("ReturnLevel", retLevel);
        PlayerPrefs.Save();
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLibraryActivities()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLibraryGames()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadLibraryMoving()
    {
        SceneManager.LoadScene(6);
    }

        public void LoadHelp()
    {
        Handheld.PlayFullScreenMovie("librarytutorial.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }
}
