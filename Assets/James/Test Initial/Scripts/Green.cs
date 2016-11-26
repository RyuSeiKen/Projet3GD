using UnityEngine;
using System.Collections;

public class Green : MonoBehaviour 
{
	public float integrationLevel = 1;

	void Update () 
	{
		transform.Rotate(new Vector3(0, 0, 15 * integrationLevel));
	}
}
