using UnityEngine;
using System.Collections;

public class MurGlisse : MonoBehaviour {
	

	public KeyCode _up;
	public GameObject player;
	float speed;
	bool OnWall;

	// Use this for initialization
	void Start () {
		OnWall = false;

	}
	
	// Update is called once per frame
	void OnTriggerEnter () {
		
		OnWall = true;
	}

	void OnTriggerExit()
	{
		
		OnWall = false;
	}

	void Update()

	{
		speed = player.GetComponent<Move> ().Speed;
		if (OnWall == false) {
			player.GetComponent<Rigidbody> ().useGravity = true;

		}




		if (Input.GetKey(_up) && OnWall == true && speed > 0.38f)
		{	
			
			player.GetComponent<Rigidbody> ().useGravity = false;
			player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		
		} else { OnWall = false;}

	}
}
