using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object for a simple attack
/// </summary>
[CreateAssetMenu(menuName = "Ability/Physical/Attack")]
public class Attack : Ability
{
	public override void Activate(CombatActor user, List<CombatActor> targets)
	{
		throw new System.NotImplementedException();
	}
}
