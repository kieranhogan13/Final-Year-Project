using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int score;
    public GameObject[] buttons;
    public Camera cam;

    void Awake()
    {
        
        buttons = GameObject.FindGameObjectsWithTag("Button");

        if (PlayerPrefs.HasKey("bgR"))
        {
            Color color0 = new Color(PlayerPrefs.GetFloat("bgR"), PlayerPrefs.GetFloat("bgG"), PlayerPrefs.GetFloat("bgB"), 1);
            cam.backgroundColor = color0;
        }
        if (PlayerPrefs.HasKey("btX"))
        {
            foreach (GameObject button in buttons)
            {
                button.transform.localScale = new Vector3(PlayerPrefs.GetFloat("btX"), PlayerPrefs.GetFloat("btY"), 1);
            }
        }
    }

    public void AddPoints(int points)
    {
        score += points;
    }

    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", 8);
    }

    void OnGUI()
    {
        GUILayout.Label(score.ToString());
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
