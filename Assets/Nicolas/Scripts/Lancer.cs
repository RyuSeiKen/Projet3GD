using UnityEngine;
using System.Collections;

public class Lancer : MonoBehaviour {

	public KeyCode saut;
	public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (saut)) 
		{
			GameObject newproj = Instantiate(projectile);
			newproj.transform.position = gameObject.transform.position + new Vector3 (0, 1, 0);

		}

	}
}
