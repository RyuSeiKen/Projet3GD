using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour 
{
	Camera cam;

	void Start()
	{
		cam = FindObjectOfType<Camera>();
	}

	void Update () 
	{
		transform.forward = new Vector3(transform.position.x - cam.transform.position.x, transform.position.y - cam.transform.position.y, transform.position.z - cam.transform.position.z);
	}
}
