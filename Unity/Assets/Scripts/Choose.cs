//Controls level select scene

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public int retLevel;

    void Start ()
    {
        PlayerPrefs.SetInt("ReturnLevel", retLevel);
        PlayerPrefs.Save();
    }
	
	void Update () {
	
	}

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(9);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(12);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(15);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(18);
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(21);
    }
}
