using UnityEngine;
using System.Collections;

public class Blue : MonoBehaviour 
{
	public float integrationLevel = 1;

	GameObject idol;

	void Start () 
	{
		idol =  GameObject.FindGameObjectWithTag("Idol");
	}

	void Update () 
	{
		transform.RotateAround(idol.transform.position, Vector3.forward, 3 * integrationLevel);
	}
}
