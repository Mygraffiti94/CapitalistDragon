using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
	[SerializeField] public bool hasEncounters = true;
	[SerializeField] public GameObject battlefield;
	[SerializeField] public GameObject mainGame;
	[SerializeField] public EncounterSpawner spawner;
	[SerializeField] public Party party;

	public void StartEncounter()
	{
		Debug.Log("Encounter start");
		battlefield.SetActive(true);
		mainGame.SetActive(false);
		GameManager.instance.SetControlScheme(ControlScheme.Battle);

		foreach(CombatActor combatActor in GameManager.instance.player.GetComponent<Party>().members)
		{
			Actor actor = GameManager.instance.player.GetComponent<Actor>();
			combatActor.statList = actor.statList;
			combatActor.StatStructure = actor.StatStructure;
		}

		spawner.SpawnEncounter(GameManager.instance.player.GetComponent<Party>());
	}

	public void EndEncounter()
	{
		spawner.RemoveObjectsAfterEncounter();
		battlefield.SetActive(false);
		mainGame.SetActive(true);
		GameManager.instance.SetControlScheme(ControlScheme.Exploration);
	}

	public void Update()
	{
		if(Input.GetKeyUp(KeyCode.F))
		{
			EndEncounter();	
		}
	}
}
