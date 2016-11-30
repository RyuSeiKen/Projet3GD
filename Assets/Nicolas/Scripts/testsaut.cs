using UnityEngine;
using System.Collections;

public class testsaut : MonoBehaviour {

    public KeyCode saut;
    public ForceMode forcee;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(saut))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,1000,1000), forcee);
        }
	}
}
