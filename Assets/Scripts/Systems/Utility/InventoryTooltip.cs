using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;
using UnityEngine.UI;

public class InventoryTooltip : MonoBehaviour
{
	[SerializeField] private GameObject	popupCanvasObject;
	[SerializeField] private RectTransform popupObject;
	[SerializeField] private TextMeshProUGUI infoText;
	[SerializeField] private TextMeshProUGUI itemName;
	[SerializeField] private Vector3 offset;
	[SerializeField] private float padding;

	private Canvas popupCanvas;

	private void Awake()
	{
		popupCanvas = popupCanvasObject.GetComponent<Canvas>();
	}

	private void Update()
	{
		FollowCursor();
	}

	private void FollowCursor()
	{
		if(popupCanvasObject.activeSelf == false)
			return;

		Vector3 newPos = Input.mousePosition + offset;
		newPos.z = 0f;

		// Calculate the offsets between the edge of the screen and the edge of the screen for the left, right, and top of the window
		// If any are off the edges, we add in the padding distance so that none of the window goes off the edge
		float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + (popupObject.rect.width * popupCanvas.scaleFactor / 2)) - padding;
		if(rightEdgeToScreenEdgeDistance < 0f)
		{
			newPos.x += rightEdgeToScreenEdgeDistance;
		}

		float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - (popupObject.rect.width * popupCanvas.scaleFactor / 2)) + padding;
		if(leftEdgeToScreenEdgeDistance > 0f)
		{
			newPos.x += leftEdgeToScreenEdgeDistance;
		}

		float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
		if(topEdgeToScreenEdgeDistance < 0)
		{
			newPos.y += topEdgeToScreenEdgeDistance;
		}
		popupObject.transform.position = newPos;
	}

	public void DisplayInfo(Item item)
	{
		StringBuilder builder = new StringBuilder();

		builder.Append("<b><u><size=24>").Append(item.itemName).Append("</size></u></b>").AppendLine();
		switch (item.itemRarity)
		{ 
			case ItemRarity.Legendary:
				itemName.color = ItemRarityColor.GetLegendaryColor();
				break;
			case ItemRarity.Epic:
				itemName.color = ItemRarityColor.GetEpicColor();
				break;
			case ItemRarity.Rare:
				itemName.color = ItemRarityColor.GetRareColor();
				break;
			case ItemRarity.Common:
			default:
				itemName.color = ItemRarityColor.GetCommonColor();
				break;
		}
		itemName.text = builder.ToString();

		builder = new StringBuilder();
		for(int i = 0; i < item.stats.values.Count; i++)
		{
			builder.Append("<size=18>").Append(item.stats.values[i].valueName).Append(": ").Append(item.stats.integers[i]).Append("</size>").AppendLine();
		}

		infoText.text = builder.ToString();
		popupCanvasObject.SetActive(true);
		LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
	}

	public void HideInfo()
	{
		popupCanvasObject.SetActive(false);
	}
}
