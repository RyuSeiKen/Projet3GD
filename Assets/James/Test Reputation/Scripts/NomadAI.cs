using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NomadAI : MonoBehaviour 
{
	public string color;
	Base myBase;
	Base[] baseArray;
	public List<Vector3> travelPoints;
	public List<Base> enemyBases;
	public List<Base> friendlyBases;
	Vector3 nextPoint;

	void Start () 
	{
		myBase = GameObject.Find(color + " Base").GetComponent<Base>();
		friendlyBases.Add(myBase.GetComponent<Base>());
		baseArray = FindObjectsOfType<Base>();
		for(int i = 0; i < baseArray.Length; i++)
		{
			travelPoints.Add(baseArray[i].GetComponent<Base>().spot);
		}
		nextPoint = travelPoints[Random.Range(0, travelPoints.Count)];
		GetComponent<NavMeshAgent>().SetDestination(nextPoint);
		GetComponent<NavMeshAgent>().avoidancePriority = Random.Range(0, 100);
	}

	void Update () 
	{
		GetComponent<NavMeshAgent>().speed = 2;
		if(Vector3.Distance(transform.position, nextPoint) < 1f)
		{
			nextPoint = travelPoints[Random.Range(0, travelPoints.Count)];
			GetComponent<NavMeshAgent>().SetDestination(nextPoint);
		}
		foreach(Base b in enemyBases)
		{
			if(b.spot == nextPoint)
			{
				nextPoint = travelPoints[Random.Range(0, travelPoints.Count)];
				GetComponent<NavMeshAgent>().SetDestination(nextPoint);
			}
		}
		foreach(Base b in friendlyBases)
		{
			if(b.spot == nextPoint)
			{
				GetComponent<NavMeshAgent>().speed = 5;
			}
		}
	}
}
