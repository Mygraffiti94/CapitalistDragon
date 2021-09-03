using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DamageType
{
	Physical,
	Fire,
	Ice,
	Wind,
	Earth,
	Lightning,
	Dark,
	Holy
}

enum SpellTargetArea
{ 
	Single,
	Row,
	Full,
	Self
}

public abstract class Ability : ScriptableObject
{
	public string abilityName;

	abstract public void Activate(CombatActor user, List<CombatActor> targets);
	virtual public bool Check(CombatActor user)
	{
		return true;
	}
}
