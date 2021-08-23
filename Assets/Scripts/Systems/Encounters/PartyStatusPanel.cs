using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartyStatusPanel : MonoBehaviour
{
	[SerializeField] Value goldValue;
	[SerializeField] Value maxGoldValue;
	public GameObject playerNamePanel;
	public GameObject playerNamePrefab;
	public GameObject goldTextPanel;
	public GameObject goldTextPrefab;

	public void InitializePartyDisplay(List<CombatActor> partyList)
	{
		for(int i = 0; i < partyList.Count; i++)
		{
			GameObject memberName = Instantiate(playerNamePrefab, playerNamePanel.transform);
			memberName.GetComponentInChildren<TextMeshProUGUI>().text = partyList[i].actorName;

			GameObject goldText = Instantiate(goldTextPrefab, goldTextPanel.transform);
			int currGold = 0;
			int maxGold = 0;
			partyList[i].statList.Get(goldValue, out currGold);
			partyList[i].statList.Get(maxGoldValue, out maxGold);
			goldText.GetComponentInChildren<TextMeshProUGUI>().text = "Gold: " + currGold.ToString() + "/" + maxGold.ToString();
		}
	}
}
