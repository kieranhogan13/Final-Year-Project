using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Guess : MonoBehaviour {

    public Canvas MainCanvas, WinCanvas, LoseCanvas;
    public AudioClip welldone;
    private AudioSource source;

    public bool word1, word2, word3, word4, word5;
    public int applause, wrongWordCount, scoreSaved;

    public string levelname, category;
    public float timeplayed;
    public int score;
    public string[] top10Scores;
    public string db_url = "http://fypc12561353.cloudapp.net/";

    void Start()
    {
        PlayerPrefs.SetInt("ReturnTo", 7);
        PlayerPrefs.SetInt("CurrentLevel", 7);
        PlayerPrefs.Save();
        print(PlayerPrefs.GetInt("CurrentLevel"));
        levelname = "Level 5 - Test";
        category = "Test";
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
        // first we create a new WWWForm, that means a "post" command goes out to our database (for futher information just google "post" and "get" commands for html/php
        WWWForm form = new WWWForm();

        // with this line we will give a new name and save our score into that name
        // those "" indicate a string and attach the score after the comma to it
        form.AddField("newLevel", levelname);
        form.AddField("newCategory", category);
        form.AddField("newTime", timeplayed.ToString());
        form.AddField("newScore", score);

        print("debug: test");
        // the next line will start our php file that saves the Score and attaches the saved values from the "form" to it
        // For this tutorial I've used a new variable "db_url" that stores the path
        WWW webRequest = new WWW(db_url + "save.php", form);

        // with this line we'll wait until we get an info back
        yield return webRequest;

        string webRequestString = webRequest.text;
        print(webRequestString);
    }

    void CorrectAnswer()
    {
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
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void NextButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene(0);
    }

}
