using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour 
{
	Text text;
	string oldMessage;
	float alpha;

	void Start () 
	{
		text = GetComponent<Text>();
	}
	
	void Update () 
	{
		if(oldMessage != text.text)
		{
			alpha = 4;
		}

		if(alpha == 0)
		{
			oldMessage = "";
			text.text = "";
		}
		else
		{
			oldMessage = text.text;
		}

		alpha = Mathf.MoveTowards(alpha, 0, 0.05f);
		text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
	}
}