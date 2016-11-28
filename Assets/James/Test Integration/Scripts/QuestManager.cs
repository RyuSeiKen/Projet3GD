using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour 
{	
	PlayerMembership player;

	void Start() 
	{
		player = FindObjectOfType<PlayerMembership>();
	}

	public void GreenQuest()
	{
		if(player.currentQuest == "Green")
		{
			Debug.Log("You've already accepted the green quest.");
			return;
		}
		if(player.currentQuest != "None" && player.currentQuest != "Green")
		{
			Debug.Log(player.currentQuest + " quest abandoned.");
		}
		Debug.Log("Find the item we ask for.");
		player.currentQuest = "Green";
	}

	public void BlueQuest()
	{
		if(player.currentQuest == "Blue")
		{
			Debug.Log("You've already accepted the blue quest.");
			return;
		}
		if(player.currentQuest != "None" && player.currentQuest != "Blue")
		{
			Debug.Log(player.currentQuest + " quest abandoned.");
		}
		Debug.Log("Answer the question correctly.");
		player.currentQuest = "Blue";
	}

	public void RedQuest()
	{
		if(player.currentQuest == "Red")
		{
			Debug.Log("You've already accepted the red quest.");
			return;
		}
		if(player.currentQuest != "None" && player.currentQuest != "Red")
		{
			Debug.Log(player.currentQuest + " quest abandoned.");
		}
		Debug.Log("Attack another faction.");
		player.currentQuest = "Red";
	}
}
