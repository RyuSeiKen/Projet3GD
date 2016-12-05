using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalAI : MonoBehaviour 
{
	public string color;
	Base myBase;
	public List<Vector3> homePoints;
	Vector3 nextPoint;

	void Start () 
	{
		myBase = GameObject.Find(color + " Base").GetComponent<Base>();
		for(int i = 0; i < myBase.GetComponent<Base>().homePointNumber; i++)
		{
			homePoints.Add(myBase.GetComponent<Base>().homePoints[i]);
		}
		nextPoint = homePoints[Random.Range(0, homePoints.Count)];
		GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
		GetComponent<UnityEngine.AI.NavMeshAgent>().avoidancePriority = Random.Range(0, 100);
	}
	
	void Update () 
	{
		if(Vector3.Distance(transform.position, nextPoint) < 1f)
		{
			nextPoint = homePoints[Random.Range(0, homePoints.Count)];
			GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(nextPoint);
		}
	}
}
