using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActor : MonoBehaviour
{
	public Actor actor;
	public string actorName;
	public int level;
	public List<Ability> abilities;
	public bool enemy = false;

	private void Start()
	{
		actor = GetComponent<Actor>();
		abilities = new List<Ability>(actor.abilities);
	}
}
