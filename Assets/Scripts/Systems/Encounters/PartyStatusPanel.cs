using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartyStatusPanel : MonoBehaviour
{
	[SerializeField] Value goldValue;
	[SerializeField] Value maxGoldValue;
	[SerializeField] List<GameObject> partyNamesText;
	[SerializeField] List<GameObject> goldValueText;

	public void InitializePartyDisplay(List<CombatActor> partyList)
	{
		for (int i = 0; i < partyList.Count; i++)
		{
			TextMeshProUGUI memberNameObject = partyNamesText[i].GetComponentInChildren<TextMeshProUGUI>();
			memberNameObject.text = partyList[i].actorName;
			partyNamesText[i].gameObject.SetActive(true);

			ActorStatusPanel actorStatusPanel = goldValueText[i].GetComponent<ActorStatusPanel>();
			actorStatusPanel.combatActor = partyList[i];
			actorStatusPanel.SetGoldValue();
			goldValueText[i].gameObject.SetActive(true);
		}
	}

	public void RemovePartyDetails()
	{
		foreach(GameObject gameObject in partyNamesText)
			gameObject.SetActive(false);


		foreach(GameObject gameObject in goldValueText)
			gameObject.SetActive(false);
	}
}
