using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : InteractableModule
{
	[SerializeField] Chest chest;

	public override void Interact()
	{
		chest.OpenChest();
	}
}
