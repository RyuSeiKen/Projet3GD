using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour 
{
	public string color;
	public List<Vector3> homePoints;
	public int homePointNumber = 8;

	void Awake () 
	{
		for(int i = 0; i < homePointNumber; i++)
		{
			Vector3 direction = Quaternion.Euler(0, (360 / homePointNumber) * i, 0) * (Vector3.forward * 8);
			Vector3 homePoint = transform.position + direction;
			homePoints.Add(homePoint);
		}
	}
	
	void OnDrawGizmosSelected () 
	{
		Gizmos.color = Color.red;
		for(int i = 0; i < homePoints.Count; i++)
		{
			Gizmos.DrawSphere(homePoints[i], 1f);
		}
	}
}
