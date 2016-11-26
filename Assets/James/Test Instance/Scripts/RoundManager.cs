using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour 
{
	float t;
	bool round = false;

	float roundTime = 10;
	float pauseTime = 3;

	public List<GameObject> blueTeamMembers = new List<GameObject>();
	public List<GameObject> redTeamMembers = new List<GameObject>();

	int b;
	GameObject currentBlue;
	public Vector3 blueStart;

	int r;
	GameObject currentRed;
	public Vector3 redStart;

	float score;
	GameObject winner;
	GameObject loser;

	void Update () 
	{
		t += Time.deltaTime;
		if(!round && t > pauseTime)
		{
			RoundStart();
			round = true;
			t = 0;
		}
		else if(round && t > roundTime)
		{
			RoundEnd();
			round = false;
			t = 0;
		}
	}

	void RoundStart()
	{
		b = Random.Range(0, blueTeamMembers.Count);
		r = Random.Range(0, redTeamMembers.Count);

		currentBlue = blueTeamMembers[b];
		currentRed = redTeamMembers[r];

		blueTeamMembers.RemoveAt(b);
		redTeamMembers.RemoveAt(r);

		currentBlue.gameObject.transform.position = blueStart;
		currentRed.gameObject.transform.position = redStart;

		currentBlue.GetComponent<Charge>().enabled = true;
		currentRed.GetComponent<Charge>().enabled = true;
	}

	void RoundEnd()
	{
		currentBlue.GetComponent<Charge>().enabled = false;
		currentRed.GetComponent<Charge>().enabled = false;

		score = currentBlue.transform.position.x + currentRed.transform.position.x;
		if(score > 0)
		{
			Debug.Log("Blue Wins");
			winner = currentBlue;
			loser = currentBlue;
		}
		else if(score < 0)
		{
			Debug.Log("Red Wins");
			winner = currentRed;
			loser = currentBlue;
		}
		else
		{
			Debug.Log("Draw");
		}

		if(Mathf.Abs(score) > 9)
		{
			Convert(winner, loser);
		}
		else if(Mathf.Abs(score) > 6)
		{
			Kill(loser);
		}
		else if(Mathf.Abs(score) > 3)
		{
			Steal(winner, loser);
		}
		else
		{
			Humiliate(loser);
		}

		currentBlue.SetActive(false);
		currentRed.SetActive(false);
	}

	void Humiliate(GameObject loser)
	{
		loser.GetComponent<Member>().humiliated = true;
	}

	void Steal(GameObject winner, GameObject loser)
	{
		winner.GetComponent<Member>().power++;
		loser.GetComponent<Member>().power--;
	}

	void Kill(GameObject loser)
	{
		Destroy(loser);
	}

	void Convert(GameObject winner, GameObject loser)
	{
		loser.GetComponent<Member>().side = winner.GetComponent<Member>().side;
		loser.GetComponent<Member>().enemyFlag = winner.GetComponent<Member>().enemyFlag;
		loser.GetComponent<Material>().color = winner.GetComponent<Material>().color;
	}
}
