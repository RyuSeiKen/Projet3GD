using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Membership : MonoBehaviour 
{
	[HideInInspector]
	public Material playerMat;
	[HideInInspector]
	public Material groupMat;

	[HideInInspector]
	public float integrationLevel;
	[HideInInspector]
	public string integratedGroup;
	[HideInInspector]
	public float timeSincePromotion = 3;

	int timesLeftRed;
	int timesLeftGreen;
	int timesLeftBlue;

	public bool[] groupAllowed = new bool[3]{true, true, true};

	public Text redText;
	public Text greenText;
	public Text blueText;
	public Text memberText;

	void Update () 
	{
		timeSincePromotion += Time.deltaTime;
		if (integratedGroup != "")
		{
			if(timeSincePromotion > 3 && integrationLevel < 1)
			{
				integrationLevel += 0.25f;

				if(integrationLevel == 0.25)
				{
					memberText.text = "Initiate";
				}
				else if(integrationLevel == 0.5f)
				{
					memberText.text = "Adept";
				}
				else if(integrationLevel == 0.75f)
				{
					memberText.text = "Expert";
				}
				else if(integrationLevel == 1)
				{
					memberText.text = "Master";
				}

				GetComponent<Renderer>().material.color = new Color((playerMat.color.r * (1 - integrationLevel)) + (groupMat.color.r * integrationLevel), (playerMat.color.g * (1 - integrationLevel)) + (groupMat.color.g * integrationLevel), (playerMat.color.b * (1 - integrationLevel)) + (groupMat.color.b * integrationLevel));
				timeSincePromotion = 0;
				if(integrationLevel == 1)
				{
					if(integratedGroup == "Red")
					{
						groupAllowed[1] = false;
						greenText.text = "" + 0;
						groupAllowed[2] = false;
						blueText.text = "" + 0;
					}
					if(integratedGroup == "Green")
					{
						groupAllowed[0] = false;
						redText.text = "" + 0;
						groupAllowed[2] = false;
						blueText.text = "" + 0;
					}
					if(integratedGroup == "Blue")
					{
						groupAllowed[0] = false;
						redText.text = "" + 0;
						groupAllowed[1] = false;
						greenText.text = "" + 0;
					}
				}
			}
		}

		if (GetComponent<Red>() != null)
		{
			GetComponent<Red>().integrationLevel = integrationLevel;
		}
		else if (GetComponent<Green>() != null)
		{
			GetComponent<Green>().integrationLevel = integrationLevel;
		}
		else if (GetComponent<Blue>() != null)
		{
			GetComponent<Blue>().integrationLevel = integrationLevel;
		}
			
		if (!GetComponent<PlayerControl>().immobile && integratedGroup != "")
		{
			if(integratedGroup == "Red")
			{
				Destroy(GetComponent<Red>());
				timesLeftRed++;
				redText.text = "" + (3 - timesLeftRed);
				if(timesLeftRed == 3)
				{
					groupAllowed[0] = false;
				}
			}
			else if(integratedGroup == "Green")
			{
				Destroy(GetComponent<Green>());
				timesLeftGreen++;
				greenText.text = "" + (3 - timesLeftGreen);
				if(timesLeftGreen == 3)
				{
					groupAllowed[1] = false;
				}
			}
			else if(integratedGroup == "Blue")
			{
				Destroy(GetComponent<Blue>());
				timesLeftBlue++;
				blueText.text = "" + (3 - timesLeftBlue);
				if(timesLeftBlue == 3)
				{
					groupAllowed[2] = false;
				}
			}		
			GetComponent<Renderer>().material = playerMat;
			transform.rotation = Quaternion.Euler(Vector3.zero);
			integratedGroup = "";
			integrationLevel = 0;
			timeSincePromotion = 0;
			memberText.text = "None";
		}
	}
}
