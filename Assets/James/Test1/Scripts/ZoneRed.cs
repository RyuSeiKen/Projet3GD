using UnityEngine;
using System.Collections;

public class ZoneRed : MonoBehaviour 
{
	Material mat;

	void Start() 
	{
		mat = transform.parent.GetComponent<Renderer>().material;
	}

	void OnTriggerStay(Collider collision) 
	{
		if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Red>() == null && collision.gameObject.GetComponent<PlayerControl>().immobile && collision.gameObject.GetComponent<Membership>().groupAllowed[0])
		{
			collision.gameObject.AddComponent<Red>();
			collision.GetComponent<Membership>().groupMat = mat;
			collision.GetComponent<Membership>().integratedGroup = "Red";
		}
	}
}