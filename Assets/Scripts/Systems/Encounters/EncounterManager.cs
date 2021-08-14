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

	public void StartEncounter()
	{
		Debug.Log("Encounter start");
		battlefield.SetActive(true);
		mainGame.SetActive(false);
		GameManager.instance.SetControlScheme(ControlScheme.Battle);
		spawner.SpawnEncounter();
	}

	public void EndEncounter()
	{
		spawner.RemoveCombatants();
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
