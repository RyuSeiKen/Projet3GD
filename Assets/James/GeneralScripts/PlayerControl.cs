using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
  	KeyCode Left = KeyCode.LeftArrow;
  	KeyCode Right = KeyCode.RightArrow;
   	KeyCode Up = KeyCode.UpArrow;
  	KeyCode Down = KeyCode.DownArrow;

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
	}
}