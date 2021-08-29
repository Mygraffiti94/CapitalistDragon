using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will handle the the encounter spawning with all the proper details on screen
/// </summary>
public class EncounterSpawner : MonoBehaviour
{
	[SerializeField] Transform[] enemyPositions;
	[SerializeField] PartyStatusPanel partyStatusPanel;
	[SerializeField] EnemyStatusPanel enemyStatusPanel;

	private EnemyInfo enemyInfo;
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	/// <summary>
	/// Method call that will spawn all the enemies and set the party details accordingly and begin combat
	/// </summary>
	/// <param name="party">Party members</param>
	/// <param name="enemyEncounter">Enemy encounter</param>
	public void StartEncounter(Party party, EnemyEncounter enemyEncounter)
	{
		int positionIndex = 0;

		List<CombatActor> enemies = new List<CombatActor>();
		foreach (Entity enemy in enemyEncounter.enemies)
		{
			enemy.sprite.transform.position = enemyPositions[positionIndex].position;
			GameObject enemyObject = Instantiate(enemy.sprite, transform);
			Actor actor = enemyObject.AddComponent<Actor>();
			actor.Init(enemy);
			CombatActor combatActor = enemyObject.AddComponent<CombatActor>();
			combatActor.actor = actor;
			enemies.Add(combatActor);
			positionIndex++;
		}

		enemyStatusPanel.InitializeEnemyDisplay(enemyEncounter.enemies);
		partyStatusPanel.InitializePartyDisplay(party.members);

		GameManager.instance.combat.InitiateCombat(party, enemies);
	}

	public void RemoveObjectsAfterEncounter()
	{
		foreach(Transform child in transform)
		{
			if(child.GetComponent<EnemyController>() != null)
				Destroy(child.gameObject);
			else if(child.GetComponent<CombatActor>() != null)
				Destroy(child.gameObject);
		}

		partyStatusPanel.RemovePartyDetails();
	}
}
