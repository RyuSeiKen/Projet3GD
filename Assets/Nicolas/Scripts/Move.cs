using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	Vector3 _movement;
	public float Speed = 0.2f;
	float ReduceSpeed; 

	public KeyCode _up;
	public KeyCode _down;
	public KeyCode _right;
	public KeyCode _left;

	// Use this for initialization
	void Start () {
		ReduceSpeed = Mathf.Sqrt((Speed*Speed)/2);
	}
	
	// Update is called once per frame
	void Update () {
		ReduceSpeed = Mathf.Sqrt((Speed*Speed)/2);
		_movement = gameObject.transform.position;

        if (Input.GetKey(_up))
        {
			if (Input.GetKey (_left) || Input.GetKey (_right)) 
			{
				_movement += transform.forward*ReduceSpeed;
			} else 
			{
				_movement += transform.forward*Speed;
			}
            
        }

        if (Input.GetKey(_right))
        {
			if (Input.GetKey (_up) || Input.GetKey (_down)) 
			{
				_movement += transform.right*ReduceSpeed;
			} else 
			{
				_movement += transform.right*Speed;
			}

        }

        if (Input.GetKey(_left))
        {
			if (Input.GetKey (_up) || Input.GetKey (_down)) 
			{
				_movement -= transform.right*ReduceSpeed;
			} else 
			{
				_movement -= transform.right*Speed;
			}
        }

        if (Input.GetKey(_down))
        {
			if (Input.GetKey (_left) || Input.GetKey (_right)) 
			{
				_movement -= transform.forward*ReduceSpeed;
			} else 
			{
				_movement -= transform.forward*Speed;
			}
        }


		gameObject.transform.position =	Vector3.MoveTowards(gameObject.transform.position, _movement ,1f);
    }
}
