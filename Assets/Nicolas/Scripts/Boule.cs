using UnityEngine;
using System.Collections;

public class Boule : MonoBehaviour {

	public KeyCode saut;
	Move deplacement;
	// Use this for initialization
	void Start () {

		deplacement = gameObject.GetComponent<Move> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(saut))
		{
			gameObject.transform.localScale = gameObject.transform.localScale / 3;
			deplacement.Speed = deplacement.Speed * 1.5f;
		}

		if (Input.GetKeyUp (saut)) 
		{
			gameObject.transform.localScale = gameObject.transform.localScale * 3;
			deplacement.Speed = deplacement.Speed / 1.5f;
		}

	}
}
