using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityPanelButtonHandler : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI text;

	public void UseAbility()
	{
		AbilityDetail abilityDetail = gameObject.transform.GetComponent<AbilityDetail>();
		CombatActor combatActor = GameManager.instance.combat.GetCurrentActor();
		GameManager.instance.combat.text.text = "Select a target for " + abilityDetail.abilityName;
		GameManager.instance.combat.usedAbility = abilityDetail.abilityObject;
	}
}
