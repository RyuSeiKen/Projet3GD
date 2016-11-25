using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour 
{
	[HideInInspector]
	public bool stunned = false;

	float speed;

	Member member;

	void Start () 
	{
		member = GetComponent<Member>();
	}

	void Update () 
	{
		if(!stunned)
		{
			transform.position = Vector3.MoveTowards(transform.position, member.enemyFlag.transform.position, speed);
			speed += (Time.deltaTime / 10);
		}
		else
		{
			speed = 0;
			if(GetComponent<Rigidbody>().velocity.magnitude < 1)
			{
				stunned = false;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		other.rigidbody.AddExplosionForce(600 + (150 * Random.Range(member.power - 2, member.power + 2)), transform.position, 10, 0);
		other.gameObject.GetComponent<Charge>().stunned = true;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		if(GetComponent<Rigidbody>().velocity.magnitude > 1)
		{
			Gizmos.DrawLine(transform.position, transform.position + GetComponent<Rigidbody>().velocity);
		}
	}
}