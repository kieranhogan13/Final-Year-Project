using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int score;

    public void AddPoints(int points)
    {
        score += points;
    }

    void OnGUI()
    {
        GUILayout.Label(score.ToString());
    }
}
