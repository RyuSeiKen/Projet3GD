using UnityEngine;
using System.Collections;

public class Chute : MonoBehaviour {

	public KeyCode space;

	// Use this for initialization
	void Start () {
	
	}

	void OnColliderEnter()
	{
		Physics.gravity = new Vector3 (0, -9.8f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (space)) 
		{
			Physics.gravity = new Vector3 (0, -1000f, 0);
		}

		if (Input.GetKeyUp (space)) 
		{
			Physics.gravity = new Vector3 (0, -9.8f, 0);
		}

	}
}
