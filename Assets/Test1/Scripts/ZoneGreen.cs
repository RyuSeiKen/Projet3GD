using UnityEngine;
using System.Collections;

public class ZoneGreen : MonoBehaviour 
{
	Material mat;

	void Start() 
	{
		mat = transform.parent.GetComponent<Renderer>().material;
	}

	void OnTriggerStay(Collider collision) 
	{
		if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Green>() == null && collision.gameObject.GetComponent<PlayerControl>().immobile && collision.gameObject.GetComponent<Membership>().groupAllowed[1])
		{
			collision.gameObject.AddComponent<Green>();
			collision.GetComponent<Membership>().groupMat = mat;
			collision.GetComponent<Membership>().integratedGroup = "Green";
		}
	}
}