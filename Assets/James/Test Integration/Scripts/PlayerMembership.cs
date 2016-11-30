using UnityEngine;
using System.Collections;

public class PlayerMembership : MonoBehaviour 
{	
	[HideInInspector]
	public string playerColor = "None";
	[HideInInspector]
	public string currentQuest = "None";
	[HideInInspector]
	public string groupBetrayed = "None";

	[HideInInspector]
	public bool item = false;

	// Inputs
	KeyCode R = KeyCode.R;
	KeyCode G = KeyCode.G;

	// Config
	Base[] baseArray;
	QuestManager manager;

	void Start() 
	{
		baseArray = FindObjectsOfType<Base>();
		manager = FindObjectOfType<QuestManager>();
	}

	void Update() 
	{
		if(Input.GetKeyDown(R))
		{
			Request();
		}
		if(Input.GetKeyDown(G) && currentQuest != "None" && item)
		{
			Give();
		}
	}

	void Request()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(Vector3.Distance(transform.position, closestBase.transform.position) < 10)
		{
			string color = closestBase.color;
			if(groupBetrayed == color)
			{
				manager.Refuse();
				return;
			}
			manager.GetQuest(color);
		}
	}

	void Give()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(Vector3.Distance(transform.position, closestBase.transform.position) < 10)
		{
			item = false;
			manager.QuestComplete(currentQuest);
		}
	}

	Base GetClosestBase(Base[] bases)
	{
		Base closeBase = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
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