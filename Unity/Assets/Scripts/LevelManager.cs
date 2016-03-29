using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    void Awake()
    {
        PlayerPrefs.SetInt("ReturnTo", 8);
    }

    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", 8);
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel")+1);
    }


}
