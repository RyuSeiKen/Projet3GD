using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour 
{	
	PlayerMembership player;
	QuestItem[] questItems;
	QuestItem currentItem;
	int r;

	void Start() 
	{
		player = FindObjectOfType<PlayerMembership>();
		questItems = FindObjectsOfType<QuestItem>();
	}

	public void GetQuest(string color)
	{
		if(player.currentQuest == color)
		{
			Debug.Log("You've already accepted the " + color + " quest.");
			return;
		}

		if(player.currentQuest != "None" && player.currentQuest != color)
		{
			Debug.Log(player.currentQuest + " quest abandoned.");

			player.groupBetrayed = player.currentQuest;

			questItems[r].gameObject.SetActive(true);
			currentItem.takeAble = false;
			currentItem.GetComponent<Renderer>().material.color = Color.black;
		}

		Debug.Log("Find the item we ask for.");

		r = Random.Range(0, questItems.Length);
		currentItem = questItems[r];
		questItems[r].takeAble = true;

		player.currentQuest = color;
		if(color == "Green")
		{
			questItems[r].GetComponent<Renderer>().material.color = Color.green;
		}
		else if(color == "Blue")
		{
			questItems[r].GetComponent<Renderer>().material.color = Color.blue;
		}
		if(color == "Red")
		{
			questItems[r].GetComponent<Renderer>().material.color = Color.red;
		}
	}

	public void QuestComplete(string color)
	{
		Debug.Log("Well done");

		questItems[r].gameObject.SetActive(true);
		questItems[r].takeAble = false;
		questItems[r].GetComponent<Renderer>().material.color = Color.black;

		if(player.playerColor != "None" && player.playerColor != color)
		{
			player.groupBetrayed = player.playerColor;
		}

		player.playerColor = color;
		player.currentQuest = "None";
		if(color == "Green")
		{
			player.GetComponent<Renderer>().material.color = Color.green;
		}
		else if(color == "Blue")
		{
			player.GetComponent<Renderer>().material.color = Color.blue;
		}
		if(color == "Red")
		{
			player.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	public void Refuse()
	{
		Debug.Log("Traitor!");
	}
}
