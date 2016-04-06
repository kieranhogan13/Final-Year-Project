//Checks for internet connection

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckConnection : MonoBehaviour {

   public Text connectionStatus;

    void Start () {
        connectionStatus = GetComponent<Text>();
        StartCoroutine(CheckConn());

    }
	
	void Update () {
	
	}

    private IEnumerator CheckConn()
    {
        const float timeout = 10f;
        float startTime = Time.timeSinceLevelLoad;
        var ping = new Ping("172.217.18.206");

        while (true)
        {
            connectionStatus.text = "Checking network...";
            if (ping.isDone)
            {
                connectionStatus.text = "Network available.";
                yield break;
            }
            if (Time.timeSinceLevelLoad - startTime > timeout)
            {
                connectionStatus.text = "No Network available.";
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }

}
