using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formula/Physical/Attack")]
public class AttackFormula : FormulaInt
{
	public override int Calculate(StatsContainer stats)
	{
		throw new System.NotImplementedException();
	}

	public override List<Value> GetReferences()
	{
		throw new System.NotImplementedException();
	}

	[SerializeField] Value goldValue;
	public override void Apply(StatsContainer statsContainer, int amount)
	{
		statsContainer.Subtract(goldValue, amount);

	}
}
