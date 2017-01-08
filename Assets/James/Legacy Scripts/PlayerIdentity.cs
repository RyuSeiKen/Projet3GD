using UnityEngine;
using System.Collections;

public class PlayerIdentity : MonoBehaviour 
{
	public string playerColor = "None";
	Color startCol;

	// Inputs
//	KeyCode Space = KeyCode.Space;
	KeyCode A = KeyCode.A;
	KeyCode F = KeyCode.F;

	// Config
	Base[] baseArray;
	ReputationManager manager;

	void Start() 
	{
		startCol = GetComponent<Renderer>().material.color;
		baseArray = FindObjectsOfType<Base>();
		manager = FindObjectOfType<ReputationManager>();
	}

	void Update() 
	{
//		if(Input.GetKeyDown(Space))
//		{
//			Integrate();
//		}
		if(Input.GetKeyDown(F) && playerColor != "None")
		{
			Flower();
		}
		if(Input.GetKeyDown(A) && playerColor != "None")
		{
			Agression();
		}
	}

	void Integrate()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(Vector3.Distance(transform.position, closestBase.transform.position) < 10)
		{
			playerColor = closestBase.GetComponent<Base>().color;
			GetComponent<Renderer>().material.color = closestBase.GetComponent<Renderer>().material.color;
		}
		else
		{
			playerColor = "None";
			GetComponent<Renderer>().material.color = startCol;
		}
	}

	void Flower()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(closestBase.color != playerColor && Vector3.Distance(transform.position, closestBase.transform.position) < 10)
		{
			foreach(Relation r in manager.relationList)
			{
				if(r.color1 == closestBase.color && r.color2 == playerColor || r.color1 == playerColor && r.color2 == closestBase.color)
				{
					r.relationLevel += 10;
					r.relationLevel = Mathf.Clamp(r.relationLevel, 0, 100);
					Debug.Log(r.color1 + " and " + r.color2 + " now have an affinity level of " + r.relationLevel + ".");
					manager.RelationCheck(r, r.relationLevel - 10, r.relationLevel);
					return;
				}
			}
		}
	}

	void Agression()
	{
		Base closestBase = GetClosestBase(baseArray);
		if(closestBase.color != playerColor && Vector3.Distance(transform.position, closestBase.transform.position) < 10)
		{
			foreach(Relation r in manager.relationList)
			{
				if(r.color1 == closestBase.color && r.color2 == playerColor || r.color1 == playerColor && r.color2 == closestBase.color)
				{
					r.relationLevel -= 10;
					r.relationLevel = Mathf.Clamp(r.relationLevel, 0, 100);
					Debug.Log(r.color1 + " and " + r.color2 + " now have an affinity level of " + r.relationLevel + ".");
					manager.RelationCheck(r, r.relationLevel + 10, r.relationLevel);
					return;
				}
			}
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
