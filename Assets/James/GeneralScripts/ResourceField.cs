using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceField : MonoBehaviour 
{
	public int resourcePointAmount;
	public float resourcePointDistance;
	public float respawnTime;
	public List<GameObject> resources;
	public GameObject item;
	bool recharging = false;
	float t;

	void Start()
	{
		for(int i = 0; i < resourcePointAmount; i++)
		{
			Vector3 direction = Quaternion.Euler(0, (360 / resourcePointAmount) * i, 0) * (Vector3.forward * resourcePointDistance);
			Vector3 resourcePoint = transform.position + direction;
			GameObject resource = GameObject.Instantiate(item, resourcePoint, Quaternion.identity);
			resources.Add(resource);
		}
	}

	void Update()
	{
		if(!recharging)
		{
			foreach(GameObject g in resources)
			{
				if(!g.activeSelf)
				{
					recharging = true;
				}
			}
		}

		else
		{
			t += Time.deltaTime;
			if(t > respawnTime)
			{
				foreach(GameObject g in resources)
				{
					if(!g.activeSelf)
					{
						g.SetActive(true);
						recharging = false;
						t = 0;
						break;
					}
				}
			}
		}
	}

//	void OnDrawGizmosSelected () 
//	{
//		Gizmos.color = Color.red;
//		for(int i = 0; i < resourcePoints.Count; i++)
//		{
//			Gizmos.DrawSphere(resourcePoints[i], 1f);
//		}
//	}
}
