using System;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
	//------------------------------
	// Declarations
	//------------------------------
	[SerializeField] public ValueStructure	StatStructure;
	public StatsContainer	statList;

	void Start()
    {
        Init();
    }

    void Update()
    {

    }

	#region Init Methods
	void Init()
	{
		InitValues();
		InitFormulas();
	}

	///----------------------------------------------------
	/// <summary>
	/// Initializes any formulas that may have been attached to the ValueBase items in the list of stats
	/// </summary>
	///----------------------------------------------------
	private void InitFormulas()
	{
		foreach(ValueReference value in statList.stats)
		{
			if(value.valueBase.formula)
			{
				value.Null();
				if(value.valueBase.formula is FormulaInt)
				{
					FormulaInt formula = (FormulaInt) value.valueBase.formula;
					statList.Add(value.valueBase, formula.Calculate(statList));
				}
				else if(value.valueBase.formula is FormulaFloat)
				{
					FormulaFloat formula = (FormulaFloat) value.valueBase.formula;
					statList.Add(value.valueBase, formula.Calculate(statList));
				}
			
				List<Value> references = value.valueBase.formula.GetReferences();
				for(int i = 0 ; i < references.Count; i++)
				{
					statList.Subscribe(ValueRecalculate, value.valueBase, references[i]);
				}
			}
		}
	}
	///----------------------------------------------------
	/// <summary>
	/// Initialize the stat values of the actor into the list statList
	/// </summary>
	///----------------------------------------------------
	private void InitValues()
	{
		statList = new StatsContainer();

		// On create of an actor, we need to load up the stats into the ValueStructure Values list
		for (int i = 0; i < StatStructure.values.Count; i++)
		{
			Value value = StatStructure.values[i];

			if (value is ValueFloat)
			{
				statList.stats.Add(new ValueFloatReference(value, 5f));
			}
			else if (value is ValueInt)
			{
				statList.stats.Add(new ValueIntReference(value, 5));
			}
		}
	}
	#endregion Init Methods
	///----------------------------------------------------
	/// <summary>
	/// This method will handle when a value gets updated and needs to recalculate its dependents
	/// </summary>
	/// <param name="value">Value that needs to be recalculated</param>
	///----------------------------------------------------
	public void ValueRecalculate(Value value)
	{
		FormulaInt	formulaInt;
		ValueReference valueReference = statList.GetValueReference(value);
		valueReference.Null();

		#region Formula Calls
		#region Recalculate GP
		if(valueReference.valueBase.formula is GPFormula)
		{
			formulaInt = (FormulaInt) valueReference.valueBase.formula;
			statList.SetValue(value, formulaInt.Calculate(statList));
		}
		#endregion Recalculate GP
		#endregion Formula Calls
	}
}
