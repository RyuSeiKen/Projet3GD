using UnityEngine;
using System.Collections;

public class PlayerIdentity : MonoBehaviour 
{
	public string playerGroup = "None";
	KeyCode Space = KeyCode.Space;
	GameObject[] baseList;
	GameObject closestBase;

	void Start () 
	{
		baseList = GameObject.FindGameObjectsWithTag("Base");
	}

	void Update () 
	{
		if(Input.GetKeyDown(Space))
		{
			closestBase = GetClosestBase(baseList);
			playerGroup = closestBase.GetComponent<Base>().color;
			GetComponent<Renderer>().material.color = closestBase.GetComponent<Renderer>().material.color;
		}
	}

	GameObject GetClosestBase(GameObject[] bases)
	{
		GameObject closeBase = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (GameObject t in bases)
		{
			float dist = Vector3.Distance(t.transform.position, currentPos);
			if (dist < minDist)
			{
				closeBase = t;
				minDist = dist;
			}
		}
		return closeBase;
	}
}
