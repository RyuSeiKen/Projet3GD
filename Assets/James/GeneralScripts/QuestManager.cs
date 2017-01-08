using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestManager : MonoBehaviour 
{	
	PlayerStatus player;
	QuestItem[] questItems;
	QuestItem currentItem;
	int x;

	public Text mainText;
	public Text subText;

	void Start() 
	{
		player = FindObjectOfType<PlayerStatus>();
		questItems = FindObjectsOfType<QuestItem>();
	}

	public void GetQuest(string color)
	{
		if(player.currentQuest == color)
		{
			subText.text = "You've already accepted the " + color + " quest.";
			return;
		}

		if(player.currentQuest != "None" && player.currentQuest != color)
		{
			subText.text = player.currentQuest + " quest abandoned.";

			questItems[x].gameObject.SetActive(true);
			currentItem.takeAble = false;
			currentItem.GetComponent<Renderer>().material.color = Color.black;
		}
		mainText.text = "Find the item we ask for.";

		x = Random.Range(0, questItems.Length);
		currentItem = questItems[x];
		questItems[x].takeAble = true;

		player.currentQuest = color;
		if(color == "Green")
		{
			questItems[x].GetComponent<Renderer>().material.color = Color.green;
		}
		else if(color == "Blue")
		{
			questItems[x].GetComponent<Renderer>().material.color = Color.blue;
		}
		if(color == "Red")
		{
			questItems[x].GetComponent<Renderer>().material.color = Color.red;
		}
	}

	public void QuestComplete(string color)
	{
		mainText.text = "Well done!";

		questItems[x].gameObject.SetActive(true);
		questItems[x].takeAble = false;
		questItems[x].GetComponent<Renderer>().material.color = Color.black;

		player.playerColor = color;
		player.currentQuest = "None";

		if(color == "Green")
		{
            player.gameObject.GetComponent<testsaut>().enabled = true;
            player.gameObject.GetComponent<Boule>().enabled = false;
            player.gameObject.tag = "Untagged";
            player.GetComponent<Renderer>().material.color = Color.green;
		}
		else if(color == "Blue")
		{
            player.gameObject.GetComponent<testsaut>().enabled = false;
            player.gameObject.GetComponent<Boule>().enabled = true;
            player.gameObject.tag = "Untagged";
            player.GetComponent<Renderer>().material.color = Color.blue;
		}
		else if(color == "Red")
		{
            player.gameObject.GetComponent<testsaut>().enabled = false;
			player.gameObject.GetComponent<Boule>().enabled = false;
            player.gameObject.tag = "Player";
            player.GetComponent<Renderer>().material.color = Color.red;
		}
	}
}