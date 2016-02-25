using UnityEngine;
using System.Collections;

public class DropdownController : MonoBehaviour {

    public Camera cam;
    // Use this for initialization
    void Start () {
        cam = Camera.main.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Drop0()
    {
        Color color0 = new Color(0, 0.5f, 1, 1);
        cam.backgroundColor = color0;
    }

    public void Drop1()
    {
        Color color1 = new Color(0.5f, 0.5f, 0.5f, 1);
        cam.backgroundColor = color1;
    }

    public void Drop2()
    {
        Color color2 = new Color(0.9f, 0.9f, 0.9f, 1);
        cam.backgroundColor = color2;
    }

    public void Drop3()
    {
        Color color3 = new Color(1, 1, 1, 1);
        cam.backgroundColor = color3;
    }

    public void Drop4()
    {
        Color color4 = new Color(0, 0, 0, 1);
        cam.backgroundColor = color4;
    }
}
