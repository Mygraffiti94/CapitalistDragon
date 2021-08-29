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
			// Exclude certain stats. Gold will be displayed elsewhere and wealth is a hidden stat
			if(characterStats.values[i].valueName == "Wealth" ||
			characterStats.values[i].valueName == "MaxGold" ||
			characterStats.values[i].valueName == "Gold")
				continue;

			GameObject newText = Instantiate(text, transform);
			newText.GetComponent<TextActorValue>().Set(characterStats.values[i], actor);
		}
	}
}
