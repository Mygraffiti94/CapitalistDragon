using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
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

	public string abilityName;
}
