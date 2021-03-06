using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Object that contains the instance of the item
/// </summary>
public class ItemInstance
{
	public Item itemBase;
	public int itemCount;

	public ItemInstance(Item _itemBase, int count = 1)
	{
		itemBase = _itemBase;
		itemCount = count;
	}
}

/// <summary>
/// Class that will contain the list of items
/// </summary>
public class Inventory : MonoBehaviour
{
	List<ItemInstance> inventory;
	[SerializeField] List<Item>	itemOnStart;
	public int getItemCount
	{
		get { return inventory.Count; }
	}

	// Start is called before the first frame update
	void Start()
    {
        inventory = new List<ItemInstance>();
		for(int i = 0; i < itemOnStart.Count; i++)
		{
			AddItem(itemOnStart[i]);
		}
    }

	public List<ItemInstance> GetInventory()
	{
		return inventory;
	}

    public void AddItem(Item item, int count = 1)
	{
		if(item.stackable)
		{
			ItemInstance itemInstance = inventory.Find(target => target.itemBase == item);
			if(itemInstance == null)
			{
				inventory.Add(new ItemInstance(item));
			}
			else
			{
				itemInstance.itemCount += count;
			}
		}
		else
		{
			inventory.Add(new ItemInstance(item));
		}
	}

	public void RemoveItem(Item item, int count = 1)
	{
		ItemInstance itemInstance = inventory.Find(target => target.itemBase == item);
		if (itemInstance == null)
			return;

		itemInstance.itemCount -= count;
		if(itemInstance.itemCount < 1)
			inventory.Remove(itemInstance);
	}

	internal ItemInstance GetItem(int id)
	{
		return inventory[id];
	}
}
