using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NomadAI : MonoBehaviour 
{
	public string color;
	string status = "Roam";
	Base myBase;
	Base[] baseArray;
	public List<Vector3> travelPoints;

	Vector3 nextPoint;
	PlayerStatus player;
	ReputationManager rManager;	
	public float force;
	ObjectFinder finder;

	void Start () 
	{
		myBase = GameObject.Find(color + " Base").GetComponent<Base>();
		player = FindObjectOfType<PlayerStatus>();
		baseArray = FindObjectsOfType<Base>();
		finder = FindObjectOfType<ObjectFinder>();
		rManager = FindObjectOfType<ReputationManager>();	

		for(int i = 0; i < baseArray.Length; i++)
		{
			travelPoints.Add(baseArray[i].GetComponent<Base>().spot);
		}
		nextPoint = travelPoints[Random.Range(0, travelPoints.Count)];

		GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
		GetComponent<UnityEngine.AI.NavMeshAgent>().avoidancePriority = Random.Range(0, 100);
	}

	void Update () 
	{
		GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2;
		if(Vector3.Distance(transform.position, nextPoint) < 1f)
		{
			nextPoint = travelPoints[Random.Range(0, travelPoints.Count)];
			GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
		}
		foreach(Base b in myBase.enemyBases)
		{
			if(b.spot == nextPoint)
			{
				nextPoint = travelPoints[Random.Range(0, travelPoints.Count)];
				GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
			}
		}
		foreach(Base b in myBase.friendlyBases)
		{
			if(b.spot == nextPoint)
			{
				GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 5;
			}
		}
		foreach(Relation r in rManager.relationList)
		{
			if((r.color1 == finder.GetClosestBase(baseArray).color && r.color2 == player.playerColor || r.color1 == player.playerColor && r.color2 == finder.GetClosestBase(baseArray).color) && Vector3.Distance(transform.position, player.transform.position) < 3 && r.relationLevel < 30)
			{
				status = "Charge";
				GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.transform.position);
				GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 5;
			}
		}
		if(status == "Charge" && (Vector3.Distance(myBase.transform.position, transform.position) > 8 || Vector3.Distance(player.transform.position, transform.position) > 5))
		{
			status = "Roam";
			GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
			GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject == player.gameObject && status == "Charge")
		{
			other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5.0f);
		}
	}
}
