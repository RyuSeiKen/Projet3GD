using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour 
{	
	PlayerMembership playerM;
	PlayerIdentity playerI;
	ReputationManager rManager;
	QuestItem[] questItems;
	QuestItem currentItem;
	int r;

	void Start() 
	{
		rManager =  FindObjectOfType<ReputationManager>();
		playerM = FindObjectOfType<PlayerMembership>();
		playerI = FindObjectOfType<PlayerIdentity>();
		questItems = FindObjectsOfType<QuestItem>();
	}

	public void GetQuest(string color)
	{
		if(playerM.currentQuest == color)
		{
			Debug.Log("You've already accepted the " + color + " quest.");
			return;
		}

		if(playerM.currentQuest != "None" && playerM.currentQuest != color)
		{
			Debug.Log(playerM.currentQuest + " quest abandoned.");

			playerM.groupBetrayed = playerM.currentQuest;

			questItems[r].gameObject.SetActive(true);
			currentItem.takeAble = false;
			currentItem.GetComponent<Renderer>().material.color = Color.black;
		}

		Debug.Log("Find the item we ask for.");

		r = Random.Range(0, questItems.Length);
		currentItem = questItems[r];
		questItems[r].takeAble = true;

		playerM.currentQuest = color;
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

		foreach(Relation rel in rManager.relationList)
		{
			if(rel.color1 == playerM.GetClosestBase(playerM.baseArray).color && rel.color2 == playerM.playerColor || rel.color1 == playerM.playerColor && rel.color2 == playerM.GetClosestBase(playerM.baseArray).color)
			{
				if(playerM.playerColor != "None" && playerM.playerColor != color && rel.relationLevel < 70)
				{
					playerM.groupBetrayed = playerM.playerColor;
				}
			}
		}

		playerM.playerColor = color;
		playerI.playerColor = color;
		playerM.currentQuest = "None";
		if(color == "Green")
		{
            playerM.gameObject.GetComponent<testsaut>().enabled = true;
            playerM.gameObject.GetComponent<Boule>().enabled = false;
            playerM.gameObject.tag = "Untagged";
            playerM.GetComponent<Renderer>().material.color = Color.green;
		}
		else if(color == "Blue")
		{
            playerM.gameObject.GetComponent<testsaut>().enabled = false;
            playerM.gameObject.GetComponent<Boule>().enabled = true;
            playerM.gameObject.tag = "Untagged";
            playerM.GetComponent<Renderer>().material.color = Color.blue;
		}
		if(color == "Red")
		{
            playerM.gameObject.GetComponent<testsaut>().enabled = false;
            playerM.gameObject.GetComponent<testsaut>().enabled = false;
            playerM.gameObject.tag = "Player";
            playerM.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	public void Refuse(string reason)
	{
		Debug.Log(reason);
	}
}
