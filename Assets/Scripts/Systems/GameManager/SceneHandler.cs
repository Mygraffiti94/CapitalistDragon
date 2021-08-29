using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The system script that will handle scene transitions. Named SceneHandler to dodge conflict with Unity's baked in SceneManager
/// </summary>
public class SceneHandler : MonoBehaviour
{
	[SerializeField] public GameObject battlefield;
	[SerializeField] public GameObject mainGame;

	public void SetSceneForBattleFromWorld()
	{
		battlefield.SetActive(true);
		mainGame.SetActive(false);
		GameManager.instance.SetControlScheme(ControlScheme.Battle);
	}

	public void SetSceneToWorldAfterBattle()
	{
		battlefield.SetActive(false);
		mainGame.SetActive(true);
		GameManager.instance.SetControlScheme(ControlScheme.Exploration);
	}
}
