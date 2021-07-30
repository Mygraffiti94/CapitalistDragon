using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItemsPanel : ItemPanel
{
	public override void OnInteract(int id)
	{
		Debug.Log(id);
	}

	public override void Show()
	{
        for (int i = 0; i < inventoryManager.equipment.equipmentSlots.Length; i++)
		{
			GameObject newButton = Instantiate(buttonPrefab, transform);
			newButton.GetComponent<ItemButton>().Set(inventoryManager.equipment.equipmentSlots[i].equipped, this);
		}
	}

	public override void UpdatePanel()
	{
		throw new System.NotImplementedException();
	}
}
