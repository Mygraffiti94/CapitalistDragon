using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterButtonHandler : MonoBehaviour
{
	[SerializeField] GameObject abilityPanel;

	public void DisplayAbilties()
	{
		abilityPanel.SetActive(true);
		return;
	}

	internal void SetParty(Party party)
	{
		
	}
}
