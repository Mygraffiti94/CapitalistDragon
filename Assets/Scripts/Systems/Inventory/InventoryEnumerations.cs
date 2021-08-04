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

public enum ItemRarity
{ 
	Legendary,
	Epic,
	Rare,
	Common
}

public static class ItemRarityColor
{
	public static Color32 GetLegendaryColor()
	{
		return new Color32(229, 159, 17, 255);
	}

	public static Color32 GetEpicColor()
	{
		return new Color32(162, 58, 195, 255);
	}

	public static Color32 GetRareColor()
	{
		return new Color32(18, 16, 200, 255);
	}
	public static Color32 GetCommonColor()
	{
		return new Color32(240, 240, 250, 255);
	}
}
