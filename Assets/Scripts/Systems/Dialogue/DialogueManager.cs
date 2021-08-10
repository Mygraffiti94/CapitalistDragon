using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
	public TextMeshProUGUI speaker;
	public TextMeshProUGUI dialogueText;
	public RawImage	portrait;
	public GameObject canvas;
	Queue<string> text;
	Queue<ActorObject> actor;

	private void Awake()
	{
		text = new Queue<string>();
		actor = new Queue<ActorObject>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		canvas.SetActive(true);
		GameManager.instance.SetControlScheme(ControlScheme.Dialogue);

		text.Clear();
		actor.Clear();

		for(int i = 0; i < dialogue.text.Length; i++)
		{
			text.Enqueue(dialogue.text[i]);
			actor.Enqueue(dialogue.actor[i]);
		}

		Next();
	}

	public void Next()
	{
		if(text.Count == 0)
		{
			canvas.SetActive(false);
			GameManager.instance.SetControlScheme(ControlScheme.Exploration);
			return;
		}

		ActorObject currActor = actor.Dequeue();
		if(currActor == null)
			speaker.text = "";
		else
		{
			speaker.text = currActor.actorName;
			if(portrait != null)
			{
				if(currActor.characterPortrait != null)
				{
					portrait.enabled = true;
					portrait.texture = currActor.characterPortrait.texture;
				}
				else
				{
					portrait.texture = null;
					portrait.enabled = false;
				}
			}
		}

		dialogueText.text = text.Dequeue();
	}
}
