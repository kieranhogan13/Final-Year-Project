using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    public float xMax, yMax, xMin, yMin;

    private Transform target;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.Find("Dog").transform;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
	}
}
