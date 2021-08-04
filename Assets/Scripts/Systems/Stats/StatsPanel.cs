using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
	[SerializeField] ValueStructure characterStats;
	[SerializeField] GameObject text;
	[SerializeField] Actor actor;

	private void Start()
	{
		for(int i = 0; i < characterStats.values.Count; i++)
		{
			if(characterStats.values[i].valueName == "Wealth")
				continue;

			GameObject newText = Instantiate(text, transform);
			newText.GetComponent<TextActorValue>().Set(characterStats.values[i], actor);
		}
	}
}
