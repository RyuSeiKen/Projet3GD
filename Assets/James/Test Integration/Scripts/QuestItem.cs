using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour 
{
	bool takeAble = false;

	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 100);
	}

	void OnTriggerEnter () 
	{
		if(takeAble)
		{
			gameObject.SetActive(false);
		}
	}
}
