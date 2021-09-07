using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object for a simple attack
/// </summary>
[CreateAssetMenu(menuName = "Ability/Physical/Attack")]
public class Attack : Ability
{
	[SerializeField] int damage = 100;

	public override int Activate(CombatActor user, List<CombatActor> targets)
	{
		foreach(CombatActor actor in targets)
		{
			actor.TakeDamage(damage);
		}

		return damage;
	}
}
