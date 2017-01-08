using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResourceItem : MonoBehaviour 
{
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

	void OnTriggerEnter (Collider coll) 
	{
		if(coll.GetComponent<PlayerStatus>() != null)
		{
			gameObject.SetActive(false);
			player.resources++;
			subText.text = "Resource obtained";
			player.resourceText.text = "" + player.resources;
		}
	}
}
