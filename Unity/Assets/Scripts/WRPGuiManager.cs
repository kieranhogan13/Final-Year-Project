using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
public class WRPGuiManager : MonoBehaviour {

    public string videoName = "test";   // Type the name of your video here
    public float positionX = 50.0f;     // X postion for skip button
    public float positionY = 50.0f;     // Y position for skip button
    public string msg;
    public string done = "Done";
    public string skip = "Skip";

    void Update()
    {

    }

    void OnGUI()
    {
        WRPAndroidVideoPlayerBinding.PlayVideo(videoName, 200, 200);

        WRPAndroidVideoPlayerBinding.onVideoPlaybackCompleteEvent += VideoPlayBackCompletedNormally;
        WRPAndroidVideoPlayerBinding.onVideoEndBySkipEvent += VideoPlaybackEndedBySkipButton;
        
    }

    void VideoPlayBackCompletedNormally()
    {
        SceneManager.LoadScene(2);
    }

    void VideoPlaybackEndedBySkipButton()
    {
        SceneManager.LoadScene(2);
    }
}