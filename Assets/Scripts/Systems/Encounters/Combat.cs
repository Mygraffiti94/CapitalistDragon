using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Will handle the main combat system during an encounter
/// </summary>
public class Combat : MonoBehaviour
{
	[SerializeField] public AbilityDetailPanel abilityDetailPanel;
	[SerializeField] public TextMeshProUGUI text;
	private List<CombatActor> actorList;
	private int turnIndex;

	public void InitiateCombat(Party party, List<CombatActor> encounter)
	{
		actorList = new List<CombatActor>();
		foreach (CombatActor member in party.members)
		{
			member.enemy = false;
			actorList.Add(member);
		}
		foreach (CombatActor enemy in encounter)
		{
			enemy.enemy = true;
			actorList.Add(enemy);
		}

		// TODO: Add in a fun way to do static turn orders with speed/abilty CD etc. For right now we just go in load order
		turnIndex = 0;
		BeginTurn(actorList[turnIndex]);
	}

	/// <summary>
	/// This method will start the turn of the player or enemy based off the actorList
	/// </summary>
	public void BeginTurn(CombatActor actor)
	{
		if(actor.enemy == false)
			abilityDetailPanel.Set(actor.abilities);
		else
			EndTurn();
	}

	public CombatActor GetCurrentActor()
	{
		return actorList[turnIndex];
	}

	public void EndTurn()
	{
		// Remove current actors abilities and close the panel
		foreach(Transform child in abilityDetailPanel.transform)
		{
			Destroy(child.gameObject);
		}
		abilityDetailPanel.gameObject.SetActive(false);

		if(turnIndex >= actorList.Count - 1)
			turnIndex = 0;
		else
			turnIndex++;
		BeginTurn(actorList[turnIndex]);
	}
}
