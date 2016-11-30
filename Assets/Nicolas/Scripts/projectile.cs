using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

	public ForceMode forcee;
	GameObject cam;
	GameObject Player;
		// Use this for initialization
	void Start () {
		forcee = ForceMode.Impulse;
		Player = GameObject.FindGameObjectWithTag ("Teleport");
		cam = GameObject.FindGameObjectWithTag  ("Pivot");
		gameObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 12 + new Vector3(0,12,0), forcee);
	}
	
	// Update is called once per frame
	void OnCollisionEnter () {

		Player.transform.position = gameObject.transform.position;
		Destroy (gameObject);
	
	}
}
