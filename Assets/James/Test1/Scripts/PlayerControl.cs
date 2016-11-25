using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
  	KeyCode Left = KeyCode.LeftArrow;
  	KeyCode Right = KeyCode.RightArrow;
   	KeyCode Up = KeyCode.UpArrow;
  	KeyCode Down = KeyCode.DownArrow;

	[HideInInspector]
	public float timeSinceMobile;
	[HideInInspector]
	public bool immobile = false;

  	float speed = 10;

	void Update () 
	{
	    Vector3 pos = transform.position;
	    if(Input.GetKey(Left)) 
		{
			pos.x -= speed * Time.deltaTime;
		}
	    if(Input.GetKey(Right)) 
		{
			pos.x += speed * Time.deltaTime;
		}
	    if(Input.GetKey(Down)) 
		{
			pos.y -= speed * Time.deltaTime;
		}
	    if(Input.GetKey(Up)) 
		{
			pos.y += speed * Time.deltaTime;
		}
		if(Input.anyKey) 
		{
			timeSinceMobile = 0;
		}

	    transform.position = pos;
		timeSinceMobile += Time.deltaTime;

		if(timeSinceMobile > 0.5f)
		{
			immobile = true;
		}
		else
		{
			immobile = false;
		}
	}
}