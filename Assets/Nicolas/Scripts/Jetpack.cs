using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {

	public KeyCode saut;
	public KeyCode arrière;
	public ForceMode forcee;
	public GameObject cam;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(saut))
		{
			gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.up * 20 + new Vector3(0,2000,0), forcee);

		}

		if (Input.GetKeyDown(saut))
		{
			gameObject.GetComponent<Rigidbody> ().useGravity = false;

		}
		if (Input.GetKeyUp(saut))
		{
			gameObject.GetComponent<Rigidbody> ().useGravity = true;


		}

	}
}
