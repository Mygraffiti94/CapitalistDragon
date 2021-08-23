using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActor : MonoBehaviour
{
	[SerializeField] public ValueStructure StatStructure;
	public StatsContainer statList;
	public string actorName;
	public int level;
}
