using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
