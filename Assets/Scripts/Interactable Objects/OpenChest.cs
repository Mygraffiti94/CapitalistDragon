using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactable Module to handle a chest opening
/// </summary>
public class OpenChest : InteractableModule
{
	[SerializeField] Chest chest;

	public override void Interact(GameObject actor)
	{
		chest.OpenChest(actor);
	}
}
