using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadGame(string name)
    {
        SceneManager.LoadScene(name);
    }
}
