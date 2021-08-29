using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
	public List<CombatActor> members;
	public List<Entity> onStart;
	[SerializeField] Transform objectContainer;

	private void Awake()
	{
		members = new List<CombatActor>();
		for(int i = 0; i < onStart.Count; i++)
		{
			AddCharacter(onStart[i]);
		}
	}

	public void AddCharacter(Entity entity)
	{
		GameObject entityObject = Instantiate(entity.sprite);
		entityObject.transform.parent = objectContainer;
		Actor actor = entityObject.GetComponent<Actor>();
		actor.Init(entity);
		
		CombatActor combatActor = entityObject.GetComponent<CombatActor>();
		combatActor.actor = actor;
		members.Add(combatActor);
	}
}
