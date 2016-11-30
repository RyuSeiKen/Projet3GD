using UnityEngine;
using System.Collections;

public class Invisible : MonoBehaviour {

	public KeyCode saut;
	public bool invisible;
	public Material Startmat;
	public Material InvisibleMat;
	// Use this for initialization
	void Start () {
		invisible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (saut)) 
		{
			invisible = true;
			gameObject.GetComponent<Renderer> ().material = InvisibleMat;
			gameObject.GetComponent<Move> ().Speed = gameObject.GetComponent<Move> ().Speed / 2;
		}

		if (Input.GetKeyUp (saut)) 
		{
			invisible = false;
			gameObject.GetComponent<Renderer> ().material = Startmat;
			gameObject.GetComponent<Move>().Speed = gameObject.GetComponent<Move>().Speed*2;



		}
	}
}
