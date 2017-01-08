using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestItem : MonoBehaviour 
{
	public bool takeAble = false;
	PlayerStatus player;

	Text mainText;
	Text subText;

	void Start()
	{
		player = FindObjectOfType<PlayerStatus>();
		mainText = GameObject.FindGameObjectWithTag("Main info").GetComponent<Text>();
		subText = GameObject.FindGameObjectWithTag("Sub info").GetComponent<Text>();
	}

	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 100);
	}

	void OnTriggerEnter(Collider coll) 
	{
		if(takeAble && coll.GetComponent<PlayerStatus>() != null)
		{
			gameObject.SetActive(false);
			player.item = true;
			subText.text = "Item obtained";
		}
	}
}
