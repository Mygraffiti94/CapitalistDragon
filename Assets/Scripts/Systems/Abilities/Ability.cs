using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityAnimationNames
{
	PhysicalSlashOnce,
	MagicalSingleHit
}


public enum DamageType
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

public enum SpellTargetArea
{ 
	Single,
	Row,
	Full,
	Self
}

public abstract class Ability : ScriptableObject
{
	public string abilityName;
	public Formula damageFormula;
	public float numberOfFrames;
	[SerializeField] public AbilityAnimationNames animationName;
	[SerializeField] public DamageType damageType;
	[SerializeField] public SpellTargetArea targetArea;

	abstract public int Activate(CombatActor user, List<CombatActor> targets);
	virtual public bool Check(CombatActor user)
	{
		return true;
	}
}
