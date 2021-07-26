using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Formula/GP")]
///-------------------------------------------------------------------------------------------------------------
/// <summary>
/// A method call to calculate the GP of an Actor
/// </summary>
///-------------------------------------------------------------------------------------------------------------
public class GPFormula : FormulaInt
{
	public Value	experience;
	public Value	wealth;
	int		intWlt;
	int		intExp;
	
	public override int Calculate(StatsContainer stats)
	{
		stats.Get(wealth, out intWlt);
		stats.Get(experience, out intExp);
		return (intWlt * 10) + (intExp * 2);
	}

	public override List<Value> GetReferences()
	{
		List<Value> valuesList = new List<Value>();
		valuesList.Add(experience);
		valuesList.Add(wealth);
		return valuesList;
	}
}
