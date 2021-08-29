using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
	List<CombatActor>	actorList;

	public void Init(Party party, List<CombatActor> enemies)
	{
		foreach(CombatActor member in party.members)
		{
			actorList.Add(member);
		}

		foreach(CombatActor enemy in enemies)
		{
			actorList.Add(enemy);
		}
	}

	private void Update()
	{
		if(actorList == null)
			return;
	}
}
