using UnityEngine;
using System.Collections;

public class Telekinesie : MonoBehaviour {
	
	public GameObject player;
	public GameObject cam;
	public Material bas;
	Color StartColor;
	bool Ondrag;

	public float horizontalSpeed = 2.0f;
	public float verticalSpeed = 2.0f;

	// Use this for initialization
	void Start()
	{
		StartColor = bas.color;

	}

	void OnMouseDrag () {
		if (player.GetComponent<TelekinesiePlayer> ().enabled == true) 
		{
			float h = horizontalSpeed * Input.GetAxis ("Mouse X");
			float v = verticalSpeed* Input.GetAxis ("Mouse Y");

			gameObject.transform.position += h * cam.transform.right;
			gameObject.transform.position += v * player.transform.forward;
		}					

	}


	// Update is called once per frame
	void OnMouseOver () {
		if (player.GetComponent<TelekinesiePlayer> ().enabled == true) 
		{
			if (Vector3.Distance (gameObject.transform.position, player.transform.position) < 20) {
				gameObject.GetComponent<Renderer> ().material.color = Color.red;
			}
		}
	}

	void OnMouseExit()
	{

		gameObject.GetComponent<Renderer> ().material.color = StartColor;
	}

	void Update()
	{
		if (player.GetComponent<TelekinesiePlayer> ().enabled == true) 
		{
			if (Vector3.Distance (gameObject.transform.position, player.transform.position) < 20) {
				Debug.DrawLine (gameObject.transform.position, player.transform.position);
			}
		}
	}

}
