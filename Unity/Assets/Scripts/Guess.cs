//Controls logic for guessing games

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Guess : MonoBehaviour {

    public Canvas MainCanvas, WinCanvas, LoseCanvas;
    public AudioClip welldone;
    private AudioSource source;
    public GameObject dog;
    public SceneMan sceneMan;

    public bool word1, word2, word3, word4, word5;
    public int applause, wrongWordCount, scoreSaved;

    public string levelname, category;
    public float timeplayed;
    public int score;
    public string[] top10Scores;
    public string db_url = "http://fypc12561353.cloudapp.net/";

    void Start()
    {
        dog.GetComponent<Renderer>().enabled = true;
        MainCanvas.enabled = true;
        WinCanvas.enabled = false;
        LoseCanvas.enabled = false;
        source = GetComponent<AudioSource>();
        word1 = false;
        word2 = false;
        word3 = false;
        word4 = false;
        word5 = false;
        wrongWordCount = 0;
        applause = 0;
        scoreSaved = 0;
    }

    void Awake()
    {

    }

    void Update()
    {
        if (word1 && word2 && word3 && word4)
        {
            CorrectAnswer();
        }
        if (wrongWordCount >= 3)
        {
            WrongAnswer();
        }
    }

    IEnumerator SaveScores()
    {
        WWWForm form = new WWWForm();

        form.AddField("newLevel", levelname);
        form.AddField("newCategory", category);
        form.AddField("newTime", timeplayed.ToString());
        form.AddField("newScore", score);

        WWW webRequest = new WWW(db_url + "save.php", form);

        yield return webRequest;
    }

    void CorrectAnswer()
    {
        dog.GetComponent<Renderer>().enabled = false;
        MainCanvas.enabled = false;
        WinCanvas.enabled = true;
        PlayerPrefs.SetInt("LevelProgress", 1);
        PlayerPrefs.SetFloat("LeveTime", Time.timeSinceLevelLoad);
        PlayerPrefs.Save();
        if (applause == 0)
        {
            int thisLevel = PlayerPrefs.GetInt("CurrentLevel");
            thisLevel++;
            PlayerPrefs.SetInt("CurrentLevel", thisLevel);
            PlayerPrefs.Save();
            source.PlayOneShot(welldone, 1.0f);
            applause ++;
        }

        timeplayed = Time.timeSinceLevelLoad;
        score = 1;

        if (scoreSaved == 0)
        {
            scoreSaved = 1;
            StartCoroutine(SaveScores());
        }
    }

    void WrongAnswer()
    {
        MainCanvas.enabled = false;
        LoseCanvas.enabled = true;
        PlayerPrefs.SetInt("LevelProgress", 0);
        PlayerPrefs.SetFloat("LeveTime", Time.timeSinceLevelLoad);
        PlayerPrefs.Save();

        timeplayed = Time.timeSinceLevelLoad;
        score = 0;

        if (scoreSaved == 0)
        {
            scoreSaved = 1;
            StartCoroutine(SaveScores());
        }
    }

    public void Word1Button()
    {
        word1 = true;
        word2 = false;
        word3 = false;
        word4 = false;
        word5 = false;
    }
    public void Word2Button()
    {
        word2 = true;
        word3 = false;
        word4 = false;
        word5 = false;
    }
    public void Word3Button()
    {
        word3 = true;
        word4 = false;
        word5 = false;
    }
    public void Word4Button()
    {
        word4 = true;
    }
    public void Word5Button()
    {
        word5 = true;
        wrongWordCount++;
    }

    public void TryAgainButton()
    {
        sceneMan.CurrentLevel();
    }

    public void NextButton()
    {
        sceneMan.NextLevel();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadHelp()
    {
        Handheld.PlayFullScreenMovie("wordtutorial.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }
}
