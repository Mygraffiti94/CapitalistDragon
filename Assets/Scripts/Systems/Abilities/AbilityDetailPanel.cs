using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityDetailPanel : MonoBehaviour
{
	[SerializeField] List<Ability> abilites;
	[SerializeField] GameObject abilityDetailPrefab;

	public void Set(List<Ability> abilityList)
	{
		GameObject abilityObject;
		TextMeshProUGUI text;
		Ability ability;
		AbilityDetail abilityDetail;

		for(int i = 0; i < abilityList.Count; i++)
		{
			abilityObject = Instantiate(abilityDetailPrefab, transform);
			text = abilityObject.GetComponentInChildren<TextMeshProUGUI>();
			text.text = abilityList[i].abilityName;
			abilityDetail = abilityObject.AddComponent<AbilityDetail>();
			abilityDetail.abilityIndex = i;
			abilityDetail.abilityName = abilityList[i].abilityName;
		}
	}
}
