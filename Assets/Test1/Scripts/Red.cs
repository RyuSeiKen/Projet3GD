using UnityEngine;
using System.Collections;

public class Red : MonoBehaviour 
{
	public float integrationLevel = 1;

	float f;
	float h1;
	float h2;
	float v1;
	float v2;
	float v3;
	float v4;

	Vector3 pos1;
	Vector3 pos2;
	Vector3 pos3;
	Vector3 pos4;

	Vector3 lastPos;
	bool up = true;

	void Start () 
	{
		h1 = transform.position.x;
		h2 = transform.position.x + 4;
		v1 = transform.position.y;
		v2 = transform.position.y + 2;
		v3 = transform.position.y + 4;
		v4 = transform.position.y + 6;

		pos1 = new Vector3(h1, v1, 0);
		pos2 = new Vector3(h2, v2, 0);
		pos3 = new Vector3(h1, v3, 0);
		pos4 = new Vector3(h2, v4, 0);
	}

	void Update () 
	{
		if(Vector3.Distance(transform.position, pos1) < 0.1f)
		{
			lastPos = pos1;
		}
		if(Vector3.Distance(transform.position, pos2) < 0.1f)
		{
			lastPos = pos2;
		}
		if(Vector3.Distance(transform.position, pos3) < 0.1f)
		{
			lastPos = pos3;
		}
		if(Vector3.Distance(transform.position, pos4) < 0.1f)
		{
			lastPos = pos4;
		}
			
		if(up)
		{
			if(lastPos == pos1)
			{
				transform.position = Vector3.MoveTowards(transform.position, pos2, integrationLevel / 4);
			}
			else if(lastPos == pos2)
			{
				transform.position = Vector3.MoveTowards(transform.position, pos3, integrationLevel / 4);
			}
			else if(lastPos == pos3)
			{
				transform.position = Vector3.MoveTowards(transform.position, pos4, integrationLevel / 4);
			}
			else if(lastPos == pos4)
			{
				up = false;
			}
		}
		else
		{
			if(lastPos == pos4)
			{
				transform.position = Vector3.MoveTowards(transform.position, pos3, integrationLevel / 4);
			}
			else if(lastPos == pos3)
			{
				transform.position = Vector3.MoveTowards(transform.position, pos2, integrationLevel / 4);
			}
			else if(lastPos == pos2)
			{
				transform.position = Vector3.MoveTowards(transform.position, pos1, integrationLevel / 4);
			}
			else if(lastPos == pos1)
			{
				up = true;
			}
		}
	}
}