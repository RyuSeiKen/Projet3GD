using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalAI : MonoBehaviour 
{
	public string color;
	string status = "Roam";
	Base myBase;
	public List<Vector3> homePoints;
	public Vector3 nextPoint;
	PlayerStatus player;
	ObjectFinder finder;
	Base[] baseArray;
	ReputationManager rManager;	
	public float force;
	float partyTime;
	float partyCD = 5;
	float jumpTime;
	public float jumpFrequency;

	void Start () 
	{
		myBase = GameObject.Find(color + " Base").GetComponent<Base>();

		for(int i = 0; i < myBase.GetComponent<Base>().homePointNumber; i++)
		{
			homePoints.Add(myBase.GetComponent<Base>().homePoints[i]);
		}
		nextPoint = homePoints[Random.Range(0, homePoints.Count)];

		player = FindObjectOfType<PlayerStatus>();
		baseArray = FindObjectsOfType<Base>();
		finder = FindObjectOfType<ObjectFinder>();
		rManager = FindObjectOfType<ReputationManager>();

		GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
		GetComponent<UnityEngine.AI.NavMeshAgent>().avoidancePriority = Random.Range(0, 100);
		InvokeRepeating("Jump", jumpFrequency, jumpFrequency);
	}
	
	void Update () 
	{
		partyCD += Time.deltaTime;

		if(Vector3.Distance(transform.position, nextPoint) < 1f)
		{
			nextPoint = homePoints[Random.Range(0, homePoints.Count)];
			GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
		}
		if(Vector3.Distance(transform.position, player.transform.position) < 10 && status == "Roam")
		{
			foreach(Relation r in rManager.relationList)
			{
				if((r.color1 == finder.GetClosestBase(baseArray).color && r.color2 == player.playerColor || r.color1 == player.playerColor && r.color2 == finder.GetClosestBase(baseArray).color))
				{
					if(r.relationLevel < 30)
					{
						status = "Charge";
						GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.transform.position);
						GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 5;
					}

					if(r.relationLevel > 70 && partyCD > 5)
					{
						status = "Party";
						GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.transform.position);
						GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 5;
					}
				}
			}
		}

		if(status == "Party" && (Vector3.Distance(player.transform.position, transform.position) < 5))
		{
			partyTime += Time.deltaTime * 10;
			transform.position = new Vector3(transform.position.x, (1 - Mathf.Cos(partyTime)) * 0.25f, transform.position.z);
			GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
			if(partyTime > 20)
			{
				status = "Roam";
				GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
				GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2;
				partyCD = 0;
				partyTime = 0;
			}	
		}

		if(status == "Charge" && (Vector3.Distance(myBase.transform.position, transform.position) > 12 || Vector3.Distance(player.transform.position, transform.position) > 12))
		{
			status = "Roam";
			GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
			GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2;
		}
		if(status == "Party" && (Vector3.Distance(myBase.transform.position, transform.position) > 12 || Vector3.Distance(player.transform.position, transform.position) > 12))
		{
			status = "Roam";
			GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
			GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2;
		}

		if(status == "Jump")
		{
			jumpTime += Time.deltaTime * 5;
			transform.position = new Vector3(transform.position.x, (1 - Mathf.Cos(jumpTime)), transform.position.z);
			if(jumpTime >= 2 * Mathf.PI)
			{
				status = "Roam";
				jumpTime = 0;
			}	
		}
	}

	void Jump()
	{
		status = "Jump";
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject == player.gameObject && status == "Charge")
		{
			other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5.0f);
		}
	}
}