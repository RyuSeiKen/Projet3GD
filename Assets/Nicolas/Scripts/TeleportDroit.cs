using UnityEngine;
using System.Collections;

public class TeleportDroit : MonoBehaviour {
	
	public GameObject teleportArrive;
	public GameObject cam;
	GameObject info;

	float parab;


	// Use this for initialization
	void Update()
	{
		//porte = (gameObject.transform.position + gameObject.transform.forward*10 + new Vector3 (0,2,0));
		//arrive = (porte + new Vector3(0, -5, 0) + gameObject.transform.forward * 3);


		if (Input.GetKey(KeyCode.Space))
		{
			
				RaycastHit hit;
			Ray distanceTeleport = new Ray(gameObject.transform.position, gameObject.transform.forward * 10 );

			Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + (gameObject.transform.forward * 10), Color.red);

				
			if (Physics.Raycast (distanceTeleport, out hit) && Vector3.Distance (gameObject.transform.position,hit.point)<10) {

				if (info == null) {
					info = Instantiate (teleportArrive);
						
				} else {

					info.transform.position = hit.point;
						
				}


			} else 
			{
				if (info == null) {
					info = Instantiate (teleportArrive);

				} else {

					info.transform.position = gameObject.transform.position + (gameObject.transform.forward * 10);

				}
			}

			}
			//RaycastHit hit;
			//Ray teleportCheck = new Ray (porte, gameObject.transform.forward * 3 + new Vector3(0, -3, 0)); 
			//Ray distanceTeleport = new Ray (gameObject.transform.position, (cam.transform.forward * 3 + new Vector3(0, 3, 0)));
			//Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + (cam.transform.forward * 30 + new Vector3(0,3,0)), Color.red);






		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (info)
			{
				gameObject.transform.position = info.transform.position + new Vector3(0, 1, 0);
				Destroy(info);
			}
			else
			{
				gameObject.transform.position = gameObject.transform.position;
			}
		}

	}

	// Update is called once per frame

}
