using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	public GameObject _pivot;
	public GameObject _player;

	public float horizontalSpeed = 2.0f;
	public float verticalSpeed = 2.0f;

	public float Sensivity = 1f;
	public bool InvertY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		Screen.lockCursor = true;
//
//		if (Input.GetKey (KeyCode.Escape)) 
//		{
//			Screen.lockCursor = false;
//		}


		float h = horizontalSpeed * Input.GetAxis ("Mouse X");
		float v = verticalSpeed* Input.GetAxis ("Mouse Y");

		h = Mathf.Clamp (h, -5*Sensivity, 5*Sensivity);
		v = Mathf.Clamp (v, -5*Sensivity, 5*Sensivity);

		if (InvertY) 
		{
			v = -v;
		}
		float rotationX = _pivot.transform.rotation.eulerAngles.x;

		if (rotationX + v > 355) {
			Debug.Log ("hack");

			_pivot.transform.Rotate (v, 0, 0);
		} else 
		{
			float CalculateRotation = Mathf.Clamp (rotationX + v, 0, 89);
			

			v = CalculateRotation - rotationX;

			_pivot.transform.Rotate (v, 0, 0);
		}

		_player.transform.Rotate (0, h, 0);
	}
}
