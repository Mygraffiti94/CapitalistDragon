using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This will handle the activation of abilities when used off the abilities panel
/// </summary>
public class AbilityPanelButtonHandler : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI text;

	/// <summary>
	/// Method call triggered when an ability button is clicked
	/// </summary>
	public void UseAbility()
	{
		AbilityDetail abilityDetail = gameObject.transform.GetComponent<AbilityDetail>();
		CombatActor combatActor = GameManager.instance.combat.GetCurrentActor();
		GameManager.instance.combat.text.text = "Select a target for " + abilityDetail.abilityName;
		GameManager.instance.combat.usedAbility = abilityDetail.abilityObject;
	}
}
