using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSpawner : MonoBehaviour
{
	[SerializeField] Transform[] enemyPositions;
	[SerializeField] Transform[] playerPositions;
	[SerializeField] EncounterList encounterList;

	private EnemyEncounter enemyEncounter;
	private EnemyInfo enemyInfo;
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	public void SpawnEncounter(Party party)
	{
		int positionIndex = 0;

		int index = UnityEngine.Random.Range(0, (encounterList.encounters.Count));

		enemyEncounter = encounterList.encounters[index];
		foreach (Enemy enemy in enemyEncounter.enemies)
		{
			enemy.sprite.transform.position = enemyPositions[positionIndex].position;
			Instantiate(enemy.sprite, transform);
			positionIndex++;
		}

		positionIndex = 0;
		foreach(CombatActor member in party.members)
		{
			member.transform.position = playerPositions[positionIndex].position;
			Instantiate(member, transform);
			positionIndex++;
		}
	}

	public void RemoveCombatants()
	{
		foreach(Transform child in transform)
		{
			if(child.GetComponent<EnemyController>() != null)
				Destroy(child.gameObject);
		}
	}
}
