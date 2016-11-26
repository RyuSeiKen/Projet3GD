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

  	public float speed = 10;

	void FixedUpdate () 
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
			pos.z -= speed * Time.deltaTime;
		}
	    if(Input.GetKey(Up)) 
		{
			pos.z += speed * Time.deltaTime;
		}
		transform.position = pos;


//		if(Input.anyKey) 
//		{
//			timeSinceMobile = 0;
//		}
//		timeSinceMobile += Time.deltaTime;
//		if(timeSinceMobile > 0.5f)
//		{
//			immobile = true;
//		}
//		else
//		{
//			immobile = false;
//		}
	}
}