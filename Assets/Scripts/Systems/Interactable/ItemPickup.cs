using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractableModule
{
	[SerializeField] Item item;
	[SerializeField] int count = 1;

	public override void Interact(GameObject actor)
	{
		Inventory inventory = actor.GetComponent<Inventory>();
		if(inventory != null)
			inventory.AddItem(item, count);
		gameObject.SetActive(false);
	}
}
