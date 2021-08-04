using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextActorValue : MonoBehaviour
{
	public Value trackValue;
	public Actor actor;
	TextMeshProUGUI text;

	void UpdateText()
	{
		string statString = actor.statList.GetText(trackValue);
		if(text == null)
		{
			text = GetComponent<TextMeshProUGUI>();
		}
		text.text = statString;
	}

    public void Set(Value _trackValue, Actor _actor)
	{
		actor = _actor;
		trackValue = _trackValue;
		if(text == null)
		{
			text = GetComponent<TextMeshProUGUI>();
		}
		text.text = actor.statList.GetText(trackValue);
		actor.statList.Subscribe(UpdateText, trackValue);
	}
}
