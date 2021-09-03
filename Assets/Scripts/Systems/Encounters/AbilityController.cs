using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityController : MonoBehaviour
{
	Ability ability;
	[SerializeField] private int positionIndex;
	[SerializeField] private List<GameObject> positionList;

	public void InitiateAbility(CombatActor _user, Ability _ability)
	{
		ability = _ability;
	}

	public void GetTarget()
	{
		GameManager.instance.combat.text.text = "Selected target at index " + GetIndexOfButton();
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
}
