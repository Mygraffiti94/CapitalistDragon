using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object for the base item object
/// </summary>
[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
	public string itemName;
	public int sell;
	public int buy;
	public bool stackable;
	public ItemType itemType;
	public ValueContainer stats;
}
