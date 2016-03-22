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

    public void LoadlLevel1()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(8);
    }

}
