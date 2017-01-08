using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinTool : MonoBehaviour 
{
	public string buttonColor;

	public PlayerStatus player;
	public QuestManager manager;

	void Start () 
	{
		player = FindObjectOfType<PlayerStatus>();	
		manager = FindObjectOfType<QuestManager>();	
	}

	//On fait comme si le joueur avait accompli la quête correspondante ici. 
	//Cette fonction est appelée quand le joueur click sur un bouton. 
	public void GroupSwitch()
	{
		manager.QuestComplete(buttonColor);
	}
}
