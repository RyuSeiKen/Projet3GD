using UnityEngine;
using System.Collections;

public class ObjectFinder : MonoBehaviour 
{
	public Base[] baseArray;
	PlayerStatus player;

	void Awake()
	{
		baseArray = FindObjectsOfType<Base>();
		player = FindObjectOfType<PlayerStatus>();
	}

	public Base GetClosestBase(Base[] bases)
	{
		Base closeBase = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = player.transform.position;
		foreach (Base t in bases)
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
