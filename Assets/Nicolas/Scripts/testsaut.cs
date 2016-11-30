using UnityEngine;
using System.Collections;

public class testsaut : MonoBehaviour {

	public KeyCode saut;
    public KeyCode arrière;
    public ForceMode forcee;
	public GameObject cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(saut))
        {
			gameObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 1000 + new Vector3(0,1000,0), forcee);

        }

		if (Input.GetKeyDown(arrière))
		{
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

		}

	}
}
