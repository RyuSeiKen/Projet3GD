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
	public Base[] baseArray;
	QuestManager qManager;
	ReputationManager rManager;

	void Start() 
	{
		baseArray = FindObjectsOfType<Base>();
		qManager = FindObjectOfType<QuestManager>();
		rManager = FindObjectOfType<ReputationManager>();
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
				qManager.Refuse("Traitor!");
				return;
			}
			foreach(Relation r in rManager.relationList)
			{
				if(r.color1 == closestBase.color && r.color2 == playerColor || r.color1 == playerColor && r.color2 == closestBase.color)
				{
					if(r.relationLevel < 30)
					{
						qManager.Refuse("We hate you!");
						return;
					}
					else if(r.relationLevel > 70)
					{
						qManager.QuestComplete(color);
						groupBetrayed = "None";
						return;
					}
				}
			}

			qManager.GetQuest(color);
		}
	}

	void Give()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(Vector3.Distance(transform.position, closestBase.transform.position) < 10 && closestBase.color == currentQuest)
		{
			item = false;
			qManager.QuestComplete(currentQuest);
		}
	}

	public Base GetClosestBase(Base[] bases)
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