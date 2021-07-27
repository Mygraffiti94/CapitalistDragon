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
	[SerializeField] List<ItemType> availableSlots;
	EquipmentSlot[] equipmentSlots;

	// Start is called before the first frame update
	void Start()
	{
		Init();
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
}
