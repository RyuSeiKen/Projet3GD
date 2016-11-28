using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReputationManager : MonoBehaviour 
{
	Base[] baseArray;
	NomadAI[] nomadAIs;

	public List<Relation> relationList = new List<Relation>();

	void Start () 
	{
		baseArray = FindObjectsOfType<Base>();
		nomadAIs = FindObjectsOfType<NomadAI>();
		for(int i = 0; i < baseArray.Length; i++)
		{
			for(int j = i + 1; j < baseArray.Length; j++)
			{
				relationList.Add(new Relation(baseArray[i].GetComponent<Base>().color, baseArray[j].GetComponent<Base>().color));
			}
		}
	}

	void OnDrawGizmos()
	{
		foreach(Relation r in relationList)
		{
			Gizmos.color = new Color(1f - (r.relationLevel / 100f), r.relationLevel / 100f, 0);
			Gizmos.DrawLine(r.base1.transform.position, r.base2.transform.position);
		}
	}

	public void RelationCheck(Relation r, float oldLevel, float newLevel)
	{
		if(oldLevel < newLevel && newLevel == 80)
		{
			Debug.Log(r.color1 + " and " + r.color2 + " are now good friends.");
			r.status = "Friendly";
			foreach(NomadAI n in nomadAIs)
			{
				if(n.color == r.color1)
				{
					n.friendlyBases.Add(r.base2);
				}
				else if(n.color == r.color2)
				{
					n.friendlyBases.Add(r.base1);
				}
			}
		}
		if(oldLevel > newLevel && newLevel == 70)
		{
			Debug.Log(r.color1 + " and " + r.color2 + " are no longer friends.");
			r.status = "Neutral";
			foreach(NomadAI n in nomadAIs)
			{
				if(n.color == r.color1)
				{
					n.friendlyBases.Remove(r.base2);
				}
				else if(n.color == r.color2)
				{
					n.friendlyBases.Remove(r.base1);
				}
			}
		}
		if(oldLevel > newLevel && newLevel == 20)
		{
			Debug.Log(r.color1 + " and " + r.color2 + " are now at war.");
			r.status = "Enemy";
			foreach(NomadAI n in nomadAIs)
			{
				if(n.color == r.color1)
				{
					n.enemyBases.Add(r.base2);
				}
				else if(n.color == r.color2)
				{
					n.enemyBases.Add(r.base1);
				}
			}
		}
		if(oldLevel < newLevel && newLevel == 30)
		{
			Debug.Log(r.color1 + " and " + r.color2 + " have made a truce.");
			r.status = "Neutral";
			foreach(NomadAI n in nomadAIs)
			{
				if(n.color == r.color1)
				{
					n.enemyBases.Remove(r.base2);
				}
				else if(n.color == r.color2)
				{
					n.enemyBases.Remove(r.base1);
				}
			}
		}
	}
}

public class Relation 
{
	public string color1;
	public Base base1;

	public string color2;
	public Base base2;

	public string status = "Neutral";
	public float relationLevel = 50;

	public Relation(string aColor1, string aColor2)
	{
		color1 = aColor1;
		base1 = GameObject.Find(color1 + " Base").GetComponent<Base>();
		color2 = aColor2;
		base2 = GameObject.Find(color2 + " Base").GetComponent<Base>();
	}
}