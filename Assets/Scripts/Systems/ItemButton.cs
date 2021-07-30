using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemButton : MonoBehaviour, IPointerClickHandler
{
	ItemPanel itemPanel;

	public void OnPointerClick(PointerEventData evenData)
	{
		itemPanel.OnInteract(transform.GetSiblingIndex());
	}

	public void Set(ItemInstance itemInstance, ItemPanel _itemPanel)
	{
		itemPanel = _itemPanel;
		transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemInstance.itemBase.itemName + " x" + itemInstance.itemCount.ToString();
	}

	public void Set(Item item, ItemPanel _itemPanel)
	{
		itemPanel = _itemPanel;
		if(item != null)
		{
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemName;
			return;
		}
		transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Empty";
	}
}
