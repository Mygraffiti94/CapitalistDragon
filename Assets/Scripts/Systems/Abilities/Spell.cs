using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object for a simple spell
/// </summary>
[CreateAssetMenu(menuName = "Ability/Magic/Spell")]
public class Spell : Ability
{
	[SerializeField] int damage = 100;

	public override int Activate(CombatActor user, List<CombatActor> targets)
	{
		foreach (CombatActor actor in targets)
		{
			actor.TakeDamage(damage);
		}
		
		return damage;
	}
}
