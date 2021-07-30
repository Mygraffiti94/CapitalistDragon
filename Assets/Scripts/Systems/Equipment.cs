using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	Item,
	Weapon,
	Armor,
	Accessory
}



public class Equipment : MonoBehaviour
{
	[SerializeField] public List<ItemType> availableSlots;
	[SerializeField] public EquipmentSlot[] equipmentSlots;
	[SerializeField] public List<Item> equippedItems;

	internal bool CheckAvailableSlots(ItemInstance item)
	{
		return availableSlots.Contains(item.itemBase.itemType);
	}

	// Start is called before the first frame update
	void Start()
	{
		Init();
		for (int i = 0; i < equippedItems.Count; i++)
		{
			Equip(equippedItems[i], i);
		}
	}

	private void Init()
	{
		equipmentSlots = new EquipmentSlot[availableSlots.Count];
		for(int i = 0; i < availableSlots.Count; i++)
		{
			equipmentSlots[i] = new EquipmentSlot(availableSlots[i]);
		}
	}

	public void Equip(Item toEquip, int slotNumber)
	{
		equipmentSlots[slotNumber].Equip(toEquip);
	}

	internal void Equip(Item itemBase)
	{
		int slotNum = availableSlots.FindIndex(item => item == itemBase.itemType);
		Equip(itemBase, slotNum);
	}
}
