//Controls each button in the dropdown menus

using UnityEngine;
using System.Collections;

public class DropdownController : MonoBehaviour {

    public GameObject[] buttons;
    public Camera cam;
    public float bgR, bgG, bgB, btX, btY;

    void Start () {
        cam = Camera.main.GetComponent<Camera>();
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }
	
	void Update () {
	
	}

    public void Drop0()
    {
        Color color0 = new Color(1, 1, 1, 1);
        cam.backgroundColor = color0;
        PlayerPrefs.SetFloat("bgR", 1);
        PlayerPrefs.SetFloat("bgG", 1);
        PlayerPrefs.SetFloat("bgB", 1);
        PlayerPrefs.Save();
    }

    public void Drop1()
    {
        Color color1 = new Color(0.9f, 0.9f, 0.9f, 1);
        cam.backgroundColor = color1;
        PlayerPrefs.SetFloat("bgR", 0.9f);
        PlayerPrefs.SetFloat("bgG", 0.9f);
        PlayerPrefs.SetFloat("bgB", 0.9f);
        PlayerPrefs.Save();
    }

    public void Drop2()
    {
        Color color2 = new Color(0, 0.5f, 1, 1);
        cam.backgroundColor = color2;
        PlayerPrefs.SetFloat("bgR", 0);
        PlayerPrefs.SetFloat("bgG", 0.5f);
        PlayerPrefs.SetFloat("bgB", 1f);
        PlayerPrefs.Save();
    }

    public void Drop3()
    {
        Color color3 = new Color(0.5f, 0.5f, 0.5f, 1);
        cam.backgroundColor = color3;
        PlayerPrefs.SetFloat("bgR", 0.5f);
        PlayerPrefs.SetFloat("bgG", 0.5f);
        PlayerPrefs.SetFloat("bgB", 0.5f);
        PlayerPrefs.Save();
    }

    public void Drop4()
    {
        Color color4 = new Color(0, 0, 0, 1);
        cam.backgroundColor = color4;
        PlayerPrefs.SetFloat("bgR", 0);
        PlayerPrefs.SetFloat("bgG", 0);
        PlayerPrefs.SetFloat("bgB", 0);
        PlayerPrefs.Save();
    }
    public void Drop5()
    {
        foreach (GameObject button in buttons)
        {
            button.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            PlayerPrefs.SetFloat("btX", 0.6f);
            PlayerPrefs.SetFloat("btY", 0.6f);
            PlayerPrefs.Save();
        }
    }
    public void Drop6()
    {
        foreach (GameObject button in buttons)
        {
            button.transform.localScale = new Vector3(0.75f, 0.75f, 1);
            PlayerPrefs.SetFloat("btX", 0.8f);
            PlayerPrefs.SetFloat("btY", 0.8f);
            PlayerPrefs.Save();
        }
    }
    public void Drop7()
    {
        foreach (GameObject button in buttons)
        {
            button.transform.localScale = new Vector3(1, 1, 1);
            PlayerPrefs.SetFloat("btX", 1);
            PlayerPrefs.SetFloat("btY", 1);
            PlayerPrefs.Save();
        }
    }
    public void Drop8()
    {
        foreach (GameObject button in buttons)
        {
            button.transform.localScale = new Vector3(1.25f, 1.25f, 1);
            PlayerPrefs.SetFloat("btX", 1.2f);
            PlayerPrefs.SetFloat("btY", 1.2f);
            PlayerPrefs.Save();
        }
    }
    public void Drop9()
    {
        foreach (GameObject button in buttons)
        {
            button.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            PlayerPrefs.SetFloat("btX", 1.4f);
            PlayerPrefs.SetFloat("btY", 1.4f);
            PlayerPrefs.Save();
        }
    }
}
