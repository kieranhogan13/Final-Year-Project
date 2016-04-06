//Controls current and next scene logic

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {

    public int currLevel, retLevel;

    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", currLevel);
        PlayerPrefs.SetInt("ReturnLevel", retLevel);
        PlayerPrefs.Save();
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
    }

    public void CurrentLevel()
    {
        SceneManager.LoadScene(currLevel);
    }

    public void NextLevel()
    {
        if (currLevel <= 21)
        {
            SceneManager.LoadScene(currLevel + 1);
        }
    }
}
