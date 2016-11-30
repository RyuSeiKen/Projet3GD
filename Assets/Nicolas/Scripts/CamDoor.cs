using UnityEngine;
using System.Collections;

public class CamDoor : MonoBehaviour {
	
	public GameObject Door;
	public Vector3 ClosePos;
	Vector3 StartPos;
	bool isOn;
	public GameObject player;


	// Use this for initialization
	void Start () {
		StartPos = Door.transform.position;
	}
	
	// Update is called once per frame
	void OnTriggerStay () {
		
		if (player.GetComponent<Invisible> ().enabled == true && player.GetComponent<Invisible> ().invisible == true) {
			isOn = false;
		} else {
			isOn = true;
		}

	}

	void OnTriggerExit () {
		isOn = false;
	}

	void Update()
	{
		if (isOn == true) {
			Door.transform.position = Vector3.Lerp (Door.transform.position, ClosePos, 0.1f);
		} else {
			Door.transform.position = Vector3.Lerp (Door.transform.position, StartPos, 0.1f);
		}
	}
}
