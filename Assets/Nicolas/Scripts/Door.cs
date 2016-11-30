using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Material bas;
	Color StartColor;
	public GameObject player;
	bool open;
	bool move;
	Vector3 Startpos;
	public Vector3 Openpos;


	// Use this for initialization
	void Start () {
		move = false;
		open = false;
		StartColor = bas.color;
		Startpos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void OnMouseOver () {
		if (player.GetComponent<Hack>().enabled == true) 
		{
			if (Vector3.Distance (gameObject.transform.position, player.transform.position) < 20) {
				gameObject.GetComponent<Renderer> ().material.color = Color.red;
			}


			if (Input.GetMouseButton (0) && Vector3.Distance (gameObject.transform.position, player.transform.position) < 20) {
				move = true;
			}
			
		}
	}

	void OnMouseExit(){

		gameObject.GetComponent<Renderer> ().material.color = StartColor;
	}

	void Update()
	{
		if (player.GetComponent<Hack> ().enabled == true) 
		{
			if (Vector3.Distance (gameObject.transform.position, player.transform.position) < 20) {
				Debug.DrawLine (gameObject.transform.position, player.transform.position);
			}
		}
		if (move == true) 
		{
			OpenDoor ();
		}

		if (Vector3.Distance(gameObject.transform.position, Openpos) < 0.1f && open == false)
		{
			open = true;
			move = false;
		}

		if (Vector3.Distance(gameObject.transform.position, Startpos) < 0.1f && open == true)
		{
			open = false;
			move = false;
		}
	}

	void OpenDoor()
	{
		if (open == false) 
		{
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, Openpos, 0.1f);
		} else 
		{
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, Startpos, 0.1f);
		}

	}

}
