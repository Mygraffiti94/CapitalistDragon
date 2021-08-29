using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This handles enemy detail information on the battle GUI
/// </summary>
public class EnemyStatusPanel : MonoBehaviour
{
	[SerializeField] List<GameObject> enemyNameObjects;

	/// <summary>
	/// Method call to update all the enemy detail items with the proper name and activating them to display them to the player
	/// </summary>
	/// <param name="enemyList">Enemy list to display</param>
	public void InitializeEnemyDisplay(List<Entity> enemyList)
	{
		TextMeshProUGUI enemyName;
		int i = 0;
		for(i = 0; i < enemyList.Count; i++)
		{
			enemyName = enemyNameObjects[i].GetComponentInChildren<TextMeshProUGUI>();
			enemyName.text = enemyList[i].entityName;
			enemyNameObjects[i].gameObject.SetActive(true);
		}
	}
}
