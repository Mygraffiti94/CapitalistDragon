using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This will handle any updates to the character detail panel on the battle UI
/// </summary>
public class ActorStatusPanel : MonoBehaviour
{
	[HideInInspector] public CombatActor combatActor;

	// Declarations
	[SerializeField] TextMeshProUGUI textObject;
	[SerializeField] Value goldValue;
	[SerializeField] Value maxGoldValue;
	[SerializeField] StatusBar goldBar;

	/// <summary>
	/// This method will set the gold text value on the details and then update the gold bar to match the value
	/// </summary>
	public void SetGoldValue()
	{
		int currGold = 0;
		int maxGold = 0;

		ValueIntReference currGoldReference = (ValueIntReference) combatActor.actor.statList.GetValueReference(goldValue);
		currGold =  currGoldReference.value;
		ValueIntReference maxGoldReference = (ValueIntReference) combatActor.actor.statList.GetValueReference(maxGoldValue);
		maxGold = maxGoldReference.value;

		textObject.text = "Gold: " + currGold.ToString() + "/" + maxGold.ToString();
		goldBar.Set(currGoldReference, maxGoldReference);
	}
	
	/// <summary>
	/// For testing purposes
	/// </summary>
	private void Update()
	{
		ValueIntReference currGoldReference = (ValueIntReference)combatActor.actor.statList.GetValueReference(goldValue);
		ValueIntReference maxGoldReference = (ValueIntReference)combatActor.actor.statList.GetValueReference(maxGoldValue);
		int currGold = 0;
		int maxGold = maxGoldReference.value;

		if (Input.GetKeyUp(KeyCode.A) == true)
		{
			currGoldReference.Substract(1);
			currGold = currGoldReference.value;
			goldBar.Set(currGoldReference, maxGoldReference);
			textObject.text = "Gold: " + currGold.ToString() + "/" + maxGold.ToString();
		}
		else if(Input.GetKeyUp(KeyCode.S) == true)
		{
			currGoldReference.Add(1);
			currGold = currGoldReference.value;
			goldBar.Set(currGoldReference, maxGoldReference);
			textObject.text = "Gold: " + currGold.ToString() + "/" + maxGold.ToString();
		}
	}
}
