using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinder2 : MonoBehaviour 
{
	public Vector3 Waypoint1;
	public Vector3 Waypoint2;
	public Vector3 Waypoint3;

	List<Vector3> waypoints = new List<Vector3>();

	Vector3 nextWaypoint;
	Vector3 lastWayPoint;

	int i = 0;

	void Start () 
	{
		nextWaypoint = Waypoint1;
		waypoints.Add(Waypoint1);
		waypoints.Add(Waypoint2);
		waypoints.Add(Waypoint3);
	}

	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, 0.5f);
		if(Vector3.Distance(transform.position, nextWaypoint) < 0.1f)
		{
			i++;
			if(i >= waypoints.Count)
			{
				i = 0;
			}
			nextWaypoint = waypoints[i];
			if(i == 0)
			{
				lastWayPoint = waypoints[waypoints.Count - 1];
			}
			else
			{
				lastWayPoint = waypoints[i-1];
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		if(lastWayPoint != Waypoint1)
		{
			Gizmos.DrawSphere(Waypoint1, 1);
		}
		if(lastWayPoint != Waypoint2)
		{
			Gizmos.DrawSphere(Waypoint2, 1);
		}
		if(lastWayPoint != Waypoint3)
		{
			Gizmos.DrawSphere(Waypoint3, 1);
		}
	}
}
