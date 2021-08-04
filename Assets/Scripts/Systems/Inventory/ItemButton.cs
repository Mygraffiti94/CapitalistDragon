using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private InventoryTooltip tooltipPopup;
	ItemPanel itemPanel;
	Item itemInfo;

	public void Awake()
	{
		Transform  tooltip = gameObject.transform.parent.transform.parent.transform.parent.Find("TooltipPopup");
		tooltipPopup = tooltip.GetComponent<InventoryTooltip>();
	}

	public void OnPointerClick(PointerEventData evenData)
	{
		itemPanel.OnInteract(transform.GetSiblingIndex());
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltipPopup.DisplayInfo(itemInfo);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltipPopup.HideInfo();
	}

	public void Set(ItemInstance itemInstance, ItemPanel _itemPanel)
	{
		itemPanel = _itemPanel;
		transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemInstance.itemBase.itemName + " x" + itemInstance.itemCount.ToString();
		itemInfo = itemInstance.itemBase;
	}

	public void Set(Item item, ItemPanel _itemPanel)
	{
		itemPanel = _itemPanel;
		if(item != null)
		{
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemName;
			itemInfo = item;
			return;
		}
		transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Empty";
	}
}
