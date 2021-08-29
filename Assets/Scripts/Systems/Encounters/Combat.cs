using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will handle the main combat system during an encounter
/// </summary>
public class Combat : MonoBehaviour
{
	private List<CombatActor> actorList;

	public void InitiateCombat(Party party, List<CombatActor> encounter)
	{
		actorList = new List<CombatActor>();
		foreach (CombatActor member in party.members)
		{
			actorList.Add(member);
		}
		foreach (CombatActor enemy in encounter)
		{
			actorList.Add(enemy);
		}

		// TODO: Add in a fun way to do static turn orders with speed/abilty CD etc. For right now we just go in load order
	}

	/// <summary>
	/// This method will start the turn of the player or enemy based off the actorList
	/// </summary>
	public void BeginTurn()
	{
		
	}
}
