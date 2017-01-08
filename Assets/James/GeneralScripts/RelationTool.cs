using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelationTool : MonoBehaviour 
{
	ReputationManager manager;

	public string group1;
	public Color group1Color;
	public string group2;
	public Color group2Color;

	public Text color1T;
	public Text color2T;

	public Slider Slider;
	public Toggle Lock;

	public Button WButton;
	public Button RButton;
	public Button FButton;

	float previous;

	void Start () 
	{
		manager = FindObjectOfType<ReputationManager>();

		color1T.text = group1;
		color1T.color = group1Color;
		color2T.text = group2;
		color2T.color = group2Color;

		//On associe à des évènements des listener qui déclenchent des fonctions. 
		Slider.onValueChanged.AddListener (SliderChange);
		WButton.onClick.AddListener (War);
		RButton.onClick.AddListener (Reset);
		FButton.onClick.AddListener (Friends);
	}

	void Update()
	{
		//Le slider change si le niveau de relation change.
		Slider.value = manager.FindRelation(group1, group2).relationLevel;
		//Si le toggle est coché, les autres éléments d'UI ne sont plus interactibles.
		//De plus, la valeur de la relation correspondante reprend toujours la valeur qu'elle avait la trame précédente.
		if(Lock.isOn)
		{
			Slider.interactable = false;
			WButton.interactable = false;
			RButton.interactable = false;
			FButton.interactable = false;
			manager.RelationCheck(manager.FindRelation(group1, group2), manager.FindRelation(group1, group2).relationLevel, previous);
			manager.FindRelation(group1, group2).relationLevel = previous;
		}
		else
		{
			Slider.interactable = true;
			WButton.interactable = true;
			RButton.interactable = true;
			FButton.interactable = true;
		}
		previous = manager.FindRelation(group1, group2).relationLevel;
	}

	//Le niveau de relation change si le slider change.
	public void SliderChange(float value)
	{
		const int cran = 1;
		value = Mathf.Floor(value / cran) * cran; 
		manager.RelationCheck(manager.FindRelation(group1, group2), manager.FindRelation(group1, group2).relationLevel, value);
		manager.FindRelation(group1, group2).relationLevel = Slider.value;
		Slider.value = value;

	}

	//Ce bouton set la valeur de la relation a 0.
	public void War()
	{
		int value = 0;
		manager.RelationCheck(manager.FindRelation(group1, group2), manager.FindRelation(group1, group2).relationLevel, value);
		manager.FindRelation(group1, group2).relationLevel = 0;
	}

	//Ce bouton set la valeur de la relation a 50.
	public void Reset()
	{
		int value = 50;
		manager.RelationCheck(manager.FindRelation(group1, group2), manager.FindRelation(group1, group2).relationLevel, value);
		manager.FindRelation(group1, group2).relationLevel = 50;
	}

	//Ce bouton set la valeur de la relation a 100.
	public void Friends()
	{
		int value = 100;
		manager.RelationCheck(manager.FindRelation(group1, group2), manager.FindRelation(group1, group2).relationLevel, value);
		manager.FindRelation(group1, group2).relationLevel = 100;
	}
}