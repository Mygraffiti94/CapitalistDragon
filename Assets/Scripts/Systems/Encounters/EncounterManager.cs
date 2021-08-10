using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
	[SerializeField] public bool hasEncounters = true;

	public void StartEncounter()
	{
		Debug.Log("Encounter start");
		SceneManager.LoadScene("CombatTest");
	}
}
