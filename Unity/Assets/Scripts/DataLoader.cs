using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {

    public string[] items;

	// Use this for initialization
	IEnumerator Start () {

        WWW itemsData = new WWW("http://fypc12561353.cloudapp.net/testConn.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        print(GetDataValue(items[0], "Name:"));
    }
	
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        return value;
    }
}
