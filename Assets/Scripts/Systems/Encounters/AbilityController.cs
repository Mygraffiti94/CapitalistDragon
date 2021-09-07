using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityController : MonoBehaviour
{
	[HideInInspector] private int positionIndex;
	[SerializeField] private List<GameObject> positionList;
	[HideInInspector] private GameObject currentTarget;
	[HideInInspector] private AbilityAnimator currentAbilityAnimator;
	[HideInInspector] private DamageTextPopup damageTextPopup;

	private void Awake()
	{
		currentTarget = new GameObject();
		currentAbilityAnimator = new AbilityAnimator();
	}

	public void GetTarget()
	{
		// Get the targets selected and update the Combat instance to be aware of them
		positionIndex = GetIndexOfButton();
		GameManager.instance.combat.targets = new List<CombatActor>();
		GameManager.instance.combat.targets.Add(GameManager.instance.combat.enemies[GetIndexOfButton()]);
		currentTarget = positionList[positionIndex];
		currentAbilityAnimator = currentTarget.GetComponent<AbilityAnimator>();
		damageTextPopup = currentAbilityAnimator.damageTextPopup;
	}

	private int GetIndexOfButton()
	{
		for(int i = 0; i < positionList.Count; i++)
		{
			if(EventSystem.current.currentSelectedGameObject.name == positionList[i].name)
				return i;
		}

		return -1;
	}

	/// <summary>
	/// Method call to the AbilityAnimator object to trigger the animation running
	/// </summary>
	/// <param name="targetAbility"></param>
	public void TriggerAnimation(Ability targetAbility, int damage)
	{
		currentAbilityAnimator.TriggerAnimation(targetAbility, damage);
		damageTextPopup.ShowDamage(damage);
	}
}
