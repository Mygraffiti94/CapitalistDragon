using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This will handle any relations with updating a status bar such as the gold bar
/// </summary>
public class StatusBar : MonoBehaviour
{
	// Declarations
	CombatActor combatActor;
	float filledAmount;
	Image bar;

	[SerializeField] ValueIntReference currentInt;
	[SerializeField] ValueIntReference maxInt;

	Action calculate;

	/// <summary>
	/// Method call to update the bar
	/// </summary>
	public void UpdateBar()
	{
		calculate?.Invoke();
	}

	/// <summary>
	/// Method to calculate how much of the bar needs to be filled for ValueInts
	/// </summary>
	void CalculateInt()
	{
		filledAmount = ((float)currentInt.value / maxInt.value);
		bar.fillAmount = filledAmount;
	}

	public void Set(ValueReference current, ValueReference max)
	{
		bar = GetComponent<Image>();

		if (current is ValueIntReference)
		{
			currentInt = (ValueIntReference) current;
			maxInt = (ValueIntReference) max;

			currentInt.onChange += UpdateBar;
			currentInt.onChange += UpdateBar;
			calculate = CalculateInt;
		}

		UpdateBar();
	}
}
