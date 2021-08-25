using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStatusPanel : MonoBehaviour
{
	[SerializeField] GameObject enemyStatusLeft;
	[SerializeField] GameObject enemyStatusRight;
	[SerializeField] GameObject enemyNameTextPrefab;

	public void InitializeEnemyDisplay(List<Enemy> enemyList)
	{
		GameObject enemyName;
		int i = 0;
		int halfWay = Mathf.RoundToInt((float) enemyList.Count / 2);
		for(i = 0; i < halfWay; i++)
		{
			enemyName = Instantiate(enemyNameTextPrefab, enemyStatusLeft.transform);
			enemyName.GetComponentInChildren<TextMeshProUGUI>().text = enemyList[i].enemyName;
		}

		for(; i < enemyList.Count; i++)
		{
			enemyName = Instantiate(enemyNameTextPrefab, enemyStatusRight.transform);
			enemyName.GetComponentInChildren<TextMeshProUGUI>().text = enemyList[i].enemyName;
		}
	}
}
