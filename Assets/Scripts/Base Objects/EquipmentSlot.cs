using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot
{
	ItemType itemType;
	Item equipped;

	public EquipmentSlot(ItemType _itemType)
	{
		itemType = _itemType;
	}

	internal void Equip(Item toEquip)
	{
		equipped = toEquip;
	}
}
