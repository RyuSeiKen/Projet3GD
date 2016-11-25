using UnityEngine;
using System.Collections;

public class Member : MonoBehaviour 
{
	public string side;
	[HideInInspector]
	public int power = 5;
	[HideInInspector]
	public GameObject enemyFlag;
	[HideInInspector]
	public bool humiliated;

	public RoundManager roundManager;

	void Start()
	{
		if(side == "Blue")
		{
			roundManager.blueTeamMembers.Add(gameObject);
			enemyFlag = GameObject.Find("RedFlag");
		}
		else if(side == "Red")
		{
			roundManager.redTeamMembers.Add(gameObject);
			enemyFlag = GameObject.Find("BlueFlag");
		}
		else
		{
			Debug.Log("Error : no team assigned");
		}
	}
}