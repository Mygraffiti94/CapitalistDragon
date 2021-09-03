using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
	[SerializeField] public bool hasEncounters = true;
	[SerializeField] public EncounterSpawner spawner;
	[SerializeField] public	EncounterList encounterList;

	public void StartEncounter()
	{
		Debug.Log("Encounter start");

		GameManager.instance.sceneHandler.SetSceneForBattleFromWorld();
		EnemyEncounter enemyEncounter;
		Party party;
		int index = Random.Range(0, (encounterList.encounters.Count));
		enemyEncounter = encounterList.encounters[index];
		party = GameManager.instance.player.GetComponent<Party>();
		spawner.StartEncounter(party, enemyEncounter);
	}

	public void EndEncounter()
	{
		GameManager.instance.sceneHandler.SetSceneToWorldAfterBattle();
		spawner.RemoveObjectsAfterEncounter();
	}

	public void Update()
	{
		if(Input.GetKeyUp(KeyCode.F))
		{
			EndEncounter();	
		}
	}
}
