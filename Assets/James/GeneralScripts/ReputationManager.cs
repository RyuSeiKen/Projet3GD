using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ReputationManager : MonoBehaviour 
{
	Base[] bases;
	ObjectFinder finder;
	public List<Relation> relationList = new List<Relation>();
	public Text mainText;
	public Text subText;

	void Start () 
	{
		bases = FindObjectsOfType<Base>();
		finder = FindObjectOfType<ObjectFinder>();

		for(int i = 0; i < finder.baseArray.Length; i++)
		{
			for(int j = i + 1; j < finder.baseArray.Length; j++)
			{
				relationList.Add(new Relation(finder.baseArray[i].GetComponent<Base>().color, finder.baseArray[j].GetComponent<Base>().color));
			}
		}
		InvokeRepeating("ReturnToUsual", 2.0f, 2.0f);
	}

	void ReturnToUsual()
	{
		foreach(Relation r in relationList)
		{
			r.relationLevel = Mathf.MoveTowards(r.relationLevel, 50, 1);
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

	public Relation FindRelation(string color1, string color2)
	{
		foreach(Relation r in relationList)
		{
			if(r.color1 == color1 && r.color2 == color2 || r.color1 == color2 && r.color2 == color1)
			{
				return r;
			}
		}
		return relationList[0];
	}

	public void RelationCheck(Relation r, float oldLevel, float newLevel)
	{
		if(oldLevel < newLevel && newLevel > 75 && r.status != "Friendly")
		{
			mainText.text = r.color1 + " and " + r.color2 + " are now good friends.";
			r.status = "Friendly";
			Debug.Log("Friend");
			foreach(Base b in bases)
			{
				if(b.color == r.color1)
				{
					b.friendlyBases.Add(r.base2);
					b.SendImmigrant(r.base2);
				}
				else if(b.color == r.color2)
				{
					b.friendlyBases.Add(r.base1);
					b.SendImmigrant(r.base1);
				}
			}
		}
		if(oldLevel > newLevel && newLevel < 75 && r.status == "Friendly")
		{
			mainText.text = r.color1 + " and " + r.color2 + " are no longer friends.";
			r.status = "Neutral";
			Debug.Log("!Friend");
			foreach(Base b in bases)
			{
				if(b.color == r.color1)
				{
					b.friendlyBases.Remove(r.base2);
					b.ReturnImmigrant(r.base2);
				}
				else if(b.color == r.color2)
				{
					b.friendlyBases.Remove(r.base1);
					b.ReturnImmigrant(r.base1);
				}
			}
		}
		if(oldLevel > newLevel && newLevel < 25 && r.status != "Enemy")
		{
			mainText.text = r.color1 + " and " + r.color2 + " are now at war.";
			r.status = "Enemy";
			Debug.Log("War");
			foreach(Base b in bases)
			{
				if(b.color == r.color1)
				{
					b.enemyBases.Add(r.base2);
				}
				else if(b.color == r.color2)
				{
					b.enemyBases.Add(r.base1);
				}
			}
		}
		if(oldLevel < newLevel && newLevel > 25 && r.status == "Enemy")
		{
			mainText.text = r.color1 + " and " + r.color2 + " have made a truce.";
			r.status = "Neutral";
			Debug.Log("!War");
			foreach(Base b in bases)
			{
				if(b.color == r.color1)
				{
					b.enemyBases.Remove(r.base2);
				}
				else if(b.color == r.color2)
				{
					b.enemyBases.Remove(r.base1);
				}
			}
		}
	}
}

[System.Serializable]
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