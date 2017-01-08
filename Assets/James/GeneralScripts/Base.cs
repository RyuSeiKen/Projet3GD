using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour 
{
	public string color;
	[HideInInspector]
	public List<Vector3> homePoints;
	public int homePointNumber = 8;
	public Vector3 spot;
	public List<Base> enemyBases;
	public List<Base> friendlyBases;
	public List<LocalAI> locals;
	public List<NomadAI> nomads;
	public LocalAI migrant;

	void Awake () 
	{
		foreach(Transform t in transform.parent)
		{
			if(t.GetComponent<LocalAI>())
			{
				locals.Add(t.GetComponent<LocalAI>());
			}
			else if(t.GetComponent<NomadAI>())
			{
				nomads.Add(t.GetComponent<NomadAI>());
			}
		}

		for(int i = 0; i < homePointNumber; i++)
		{
			Vector3 direction = Quaternion.Euler(0, (360 / homePointNumber) * i, 0) * (Vector3.forward * 8);
			Vector3 homePoint = transform.position + direction;
			homePoints.Add(homePoint);
		}
	}

	public void SendImmigrant(Base friendlyBase)
	{
		migrant = locals[Random.Range(0, locals.Count)].GetComponent<LocalAI>();
		migrant.homePoints.Clear();
		for(int i = 0; i < friendlyBase.GetComponent<Base>().homePointNumber; i++)
		{
			migrant.homePoints.Add(friendlyBase.GetComponent<Base>().homePoints[i]);
		}
		migrant.nextPoint = migrant.homePoints[Random.Range(0, homePoints.Count)];
		migrant.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(migrant.nextPoint);
	}

	public void ReturnImmigrant(Base exFriendlyBase)
	{
		migrant.homePoints.Clear();
		for(int i = 0; i < homePointNumber; i++)
		{
			migrant.homePoints.Add(homePoints[i]);
		}
		migrant.nextPoint = migrant.homePoints[Random.Range(0, homePoints.Count)];
		migrant.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(migrant.nextPoint);
	}
	
//	void OnDrawGizmosSelected () 
//	{
//		Gizmos.color = Color.red;
//		for(int i = 0; i < homePoints.Count; i++)
//		{
//			Gizmos.DrawSphere(homePoints[i], 1f);
//		}
//		Gizmos.color = Color.blue;
//		Gizmos.DrawSphere(spot, 1f);
//	}
}