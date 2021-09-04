using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object that will be utilized when using an ability to pass back to the Combat which ability was used
/// </summary>
public class AbilityDetail : MonoBehaviour
{
	public int abilityIndex;
	public string abilityName;
	public Ability abilityObject;
}
