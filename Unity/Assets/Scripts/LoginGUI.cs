using UnityEngine;
using System.Collections;

public class LoginGUI : MonoBehaviour {

    public DatabaseHandler _mysqlHolder;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 10, 10), "MySQL Connection State: "+ _mysqlHolder.GetConnectionState());
    }

}
