using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour 
{
	[HideInInspector]
	public bool takeAble = false;
	PlayerMembership player;

	void Start()
	{
		player = FindObjectOfType<PlayerMembership>();
	}

	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 100);
	}

	void OnTriggerEnter () 
	{
		if(takeAble)
		{
			gameObject.SetActive(false);
			player.item = true;
			Debug.Log("Item obtained");
		}
	}
}
