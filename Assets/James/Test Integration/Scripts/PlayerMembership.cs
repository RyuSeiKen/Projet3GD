using UnityEngine;
using System.Collections;

public class PlayerMembership : MonoBehaviour 
{
	public string playerColor = "None";
	public string currentQuest = "None";

	// Inputs
	KeyCode R = KeyCode.R;
//	KeyCode G = KeyCode.G;

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
//		if(Input.GetKeyDown(G) && currentQuest != "None")
//		{
//			Give();
//		}
	}

	void Request()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(Vector3.Distance(transform.position, closestBase.transform.position) < 10)
		{
			string color = closestBase.color;
			if(color == "Green")
			{
				manager.GreenQuest();
			}
			if(color == "Blue")
			{
				manager.BlueQuest();
			}
			if(color == "Red")
			{
				manager.RedQuest();
			}
		}
	}

	void Give()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(Vector3.Distance(transform.position, closestBase.transform.position) < 10)
		{

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