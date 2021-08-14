using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlScheme
{ 
	Exploration,
	Inventory,
	Dialogue,
	Battle
}

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public DialogueControl dialogueControl;
	public DialogueManager dialogueManager;
	public GameObject player;
	public GUIManager guiManager;
	public EncounterManager encounterManager;
	public InventoryControl inventoryControl;
	public PlayerControl playerControl;

	private void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		SetControlCharacter(player);
	}

	void SetControlCharacter(GameObject target)
	{
		playerControl.Init(target);
	}

	private void Update()
	{
		if(player != playerControl.character)
			SetControlCharacter(player);
	}

	/// <summary>
	/// This method will set the controls player has access by disabling various scripts/controls so that whatever system they are using
	/// is focused for that system. 
	/// </summary>
	/// <param name="controlScheme"></param>
	public void SetControlScheme(ControlScheme controlScheme)
	{
		switch (controlScheme)
		{ 
			case ControlScheme.Exploration:
				playerControl.enabled = true;
				inventoryControl.enabled = false;
				dialogueControl.enabled = false;
				break;
			case ControlScheme.Inventory:
				playerControl.enabled = false;
				inventoryControl.enabled = true;
				dialogueControl.enabled = false;
				break;
			case ControlScheme.Dialogue:
				playerControl.enabled = false;
				inventoryControl.enabled = false;
				dialogueControl.enabled = true;
				break;
			case ControlScheme.Battle:
				playerControl.enabled = false;
				inventoryControl.enabled = false;
				dialogueControl.enabled = false;
				break;
		}
	}
}
