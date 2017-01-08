using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour 
{
	public KeyCode request = KeyCode.R;
	public KeyCode give = KeyCode.G;
	public KeyCode flower = KeyCode.F;
	public KeyCode engage = KeyCode.E;

	[HideInInspector]
	public string playerColor = "None";
	[HideInInspector]
	public string currentQuest = "None";
	[HideInInspector]
	public bool item = false;
	[HideInInspector]
	public int resources = 0;

	[HideInInspector]
	public Text playerText;
	Text mainText;
	Text subText;
	[HideInInspector]
	public Text resourceText;

	ObjectFinder finder;
	QuestManager qManager;
	ReputationManager rManager;	
	Base closestBase;
	Relation relationWithCloseBase;

	void Start () 
	{
		finder = FindObjectOfType<ObjectFinder>();
		qManager = FindObjectOfType<QuestManager>();
		rManager = FindObjectOfType<ReputationManager>();
		mainText = GameObject.FindGameObjectWithTag("Main info").GetComponent<Text>();
		subText = GameObject.FindGameObjectWithTag("Sub info").GetComponent<Text>();
		resourceText = GameObject.FindGameObjectWithTag("Resource info").GetComponent<Text>();
	}
	
	void Update () 
	{
		closestBase = finder.GetClosestBase(finder.baseArray);
		relationWithCloseBase = rManager.FindRelation(playerColor, closestBase.color);

		if(Input.GetKeyDown(request))
		{
			Request();
		}
		if(Input.GetKeyDown(give))
		{
			Give();
		}
		if(Input.GetKeyDown(flower))
		{
			Flower();
		}
		if(Input.GetKeyDown(engage))
		{
			Engage();
		}

		if(Vector3.Distance(transform.position, closestBase.transform.position) < 8 && playerColor != closestBase.color && (playerColor == "None" || relationWithCloseBase.relationLevel > 20) && currentQuest == "None")
		{
			playerText.text = "R";
		}
		else if(Vector3.Distance(transform.position, closestBase.transform.position) < 8 && currentQuest == closestBase.color && item)
		{
			playerText.text = "G";
		}
		else
		{
			playerText.text = "";
		}
	}

	void Request()
	{
		if(Vector3.Distance(transform.position, closestBase.transform.position) < 8)
		{
			string color = closestBase.color;
			if(relationWithCloseBase.relationLevel < 30)
			{
				subText.text = "We hate you!";
				return;
			}
			else if(relationWithCloseBase.relationLevel > 70)
			{
				qManager.QuestComplete(color);
				return;
			}
			qManager.GetQuest(color);
		}
	}

	void Give()
	{
		if(currentQuest == "None")
		{
			subText.text = "You have not been given a quest!";
			return;
		}
		else if(!item)
		{
			subText.text = "You don't have anything to give!";
			return;
		}
		else if(closestBase.color != currentQuest)
		{
			subText.text = "You're not close enough to give an item to a group!";
			return;
		}
		else if(Vector3.Distance(transform.position, closestBase.transform.position) > 8)
		{
			subText.text = "You cannot offer this item to another group!";
			return;
		}
		else
		{
			item = false;
			qManager.QuestComplete(currentQuest);
		}
	}

	void Flower()
	{
		if(playerColor == "None")
		{
			subText.text = "You cannot make gifts until you are part of an acknowledged group!";
			return;
		}
		else if(resources == 0)
		{
			subText.text = "You do not have any flowers to give!";
			return;
		}
		else if(Vector3.Distance(transform.position, closestBase.transform.position) > 8)
		{
			subText.text = "You're not close enough to offer flowers to a group.";
			return;
		}
		else if(closestBase.color == playerColor)
		{
			subText.text = "You don't need to offer anything to your group.";
			return;
		}
		else
		{
			Relation relation = rManager.FindRelation(closestBase.color, playerColor);
			if(relation.relationLevel > 90)
			{
				subText.text = "Your relation with the " + closestBase.color + " is already great!";
				return;
			}
			else if(relation.relationLevel < 30)
			{
				subText.text = "The " + closestBase.color + " group would rather take your life than your flowers!";
				return;
			}
			else
			{
				resources--;
				resourceText.text = "" + resources;
				subText.text = "You've offered flowers to the " + closestBase.color + " group!";
				relation.relationLevel += 10;
				relation.relationLevel = Mathf.Clamp(relation.relationLevel, 0, 100);
				rManager.RelationCheck(relation, relation.relationLevel - 10, relation.relationLevel);
				return;
			}
		}
	}

	void Engage()
	{
		if(playerColor == "None")
		{
			subText.text = "You cannot attack anyone until you are part of an acknowledged group!";
			return;
		}
		else if(Vector3.Distance(transform.position, closestBase.transform.position) > 8)
		{
			subText.text = "You're not close enough to attack any group";
			return;
		}
		else if(closestBase.color == playerColor)
		{
			subText.text = "You can't attack your own group.";
			return;
		}
		else
		{
			Relation relation = rManager.FindRelation(closestBase.color, playerColor);
			subText.text = "You've violently attacked the " + closestBase.color + " group!";
			relation.relationLevel -= 10;
			relation.relationLevel = Mathf.Clamp(relation.relationLevel, 0, 100);
			rManager.RelationCheck(relation, relation.relationLevel + 10, relation.relationLevel);
			return;
		}
	}
}