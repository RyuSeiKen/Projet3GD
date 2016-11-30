using UnityEngine;
using System.Collections;

public class Accel : MonoBehaviour {

	public KeyCode saut;
	Move deplacement;
	float StartSpeed;
	float MaxSpeed;
	// Use this for initialization
	void Start () {
		StartSpeed = gameObject.GetComponent<Move> ().Speed;
		MaxSpeed =  gameObject.GetComponent<Move> ().Speed * 2;
		deplacement = gameObject.GetComponent<Move> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (saut)) {
			deplacement.Speed = Mathf.Lerp (deplacement.Speed, MaxSpeed, 0.02f);
		} else {
			deplacement.Speed = Mathf.Lerp(deplacement.Speed, StartSpeed,0.1f);
		}


			


	}
}
