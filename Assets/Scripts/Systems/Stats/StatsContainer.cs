using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsContainer : MonoBehaviour
{
	/// <summary> List of ValueReference that contains all the stats for an Actor </summary>
	public List<ValueReference> stats;

	///----------------------------------------------------
	/// <summary>
	/// Holds a mutable list of stats to use for a given actor
	/// </summary>
	///----------------------------------------------------
	public StatsContainer()
	{
		stats = new List<ValueReference>();
	}

	/// <summary>
	/// This method will add all the stats in a given ValueContainer to the current stats list
	/// </summary>
	/// <param name="stats"></param>
	internal void Sum(ValueContainer stats)
	{
		int integerIndex = 0;
		int floatIndex = 0;

		for(int i = 0; i < stats.values.Count; i++)
		{
			if(stats.values[i].GetType() == typeof(ValueFloat))
			{
				Add(stats.values[i], stats.floats[floatIndex]);
				floatIndex++;
			}
			else if(stats.values[i].GetType() == typeof(ValueInt))
			{
				Add(stats.values[i], stats.integers[integerIndex]);
				integerIndex++;
			}
		}
	}

	internal void Subtract(ValueContainer stats)
	{
		int integerIndex = 0;
		int floatIndex = 0;

		for (int i = 0; i < stats.values.Count; i++)
		{
			if (stats.values[i].GetType() == typeof(ValueFloat))
			{
				Subtract(stats.values[i], stats.floats[floatIndex]);
				floatIndex++;
			}
			else if (stats.values[i].GetType() == typeof(ValueInt))
			{
				Subtract(stats.values[i], stats.integers[integerIndex]);
				integerIndex++;
			}
		}
	}

	#region Stat Manipulation Methods
	///----------------------------------------------------
	/// <summary>
	/// Adds the passed in value to the given Value (which references a stat
	/// </summary>
	/// <param name="value">Value to look at</param>
	/// <param name="input">Number to add</param>
	///----------------------------------------------------
	public void Add(Value value, int input)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);

		if (valueReference != null)
		{
			ValueIntReference valueIntReference = (ValueIntReference)valueReference;
			valueIntReference.Add(input);
		}
		//else
		//{
		//	Debug.Log("The given stat " + value.valueName + " does not exist.");
		//}
	}

	///----------------------------------------------------
	/// <summary>
	/// Adds the passed in value to the given Value (which references a stat
	/// </summary>
	/// <param name="value">Value to look at</param>
	/// <param name="input">Number to add</param>
	///----------------------------------------------------
	public void Add(Value value, float input)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);

		if (valueReference != null)
		{
			ValueFloatReference valueFloatReference = (ValueFloatReference)valueReference;
			valueFloatReference.Add(input);
		}
		//else
		//{
		//	Debug.Log("The given stat " + value.valueName + " does not exist.");
		//}
	}

	/// <summary>
	/// Subtracts the passed in value by the given input
	/// </summary>
	/// <param name="value">Value to subtract from</param>
	/// <param name="input">Value to subtract by</param>
	public void Subtract(Value value, int input)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		if(valueReference != null)
		{ 
			ValueIntReference valueIntReference = (ValueIntReference) valueReference;
			valueIntReference.Substract(input);
		}
	}

	/// <summary>
	/// Subtracts the passed in value by the given input
	/// </summary>
	/// <param name="value">Value to subtract from</param>
	/// <param name="input">Value to subtract by</param>
	public void Subtract(Value value, float input)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		if (valueReference != null)
		{
			ValueFloatReference valueFloatReference = (ValueFloatReference)valueReference;
			valueFloatReference.Subtract(input);
		}
	}
	#endregion Stat Manipulation Methods

	#region Get/Set Calls
	public void Get(Value value, out int state)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		ValueIntReference valueIntReference = (ValueIntReference)valueReference;
		state = 0;
		if (valueIntReference != null)
			state = valueIntReference.value;
	}

	public void Get(Value value, out float state)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		ValueFloatReference valueIntReference = (ValueFloatReference)valueReference;
		state = 0;
		if (valueIntReference != null)
			state = valueIntReference.value;
	}

	///-------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Returns the full name of the stat and its value in the format of [FULL_NAME]:[VALUE]
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	///-------------------------------------------------------------------------------------------------------------
	internal string GetText(Value value)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		return valueReference.TEXT;
	}

	public void SetValue(Value value, int input)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		if (valueReference != null)
		{
			ValueIntReference valueIntReference = (ValueIntReference)valueReference;
			valueIntReference.SetValue(input);
		}
	}

	public void SetValue(Value value, float input)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		if (valueReference != null)
		{
			ValueFloatReference valueFloatReference = (ValueFloatReference)valueReference;
			valueFloatReference.SetValue(input);
		}
	}
	#endregion Get/Set Calls

	///-------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Gets the value of the given item
	/// </summary>
	/// <param name="value">Value to find</param>
	/// <returns>The valueReference</returns>
	///-------------------------------------------------------------------------------------------------------------
	public ValueReference GetValueReference(Value value)
	{
		return stats.Find(item => item.valueBase == value);
	}

	#region Subscribe Methods
	///-------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// A method call to handle attaching any given Value to an Action
	/// </summary>
	/// <param name="action">Method that triggers change</param>
	/// <param name="value">Value that triggered the change/param>
	///-------------------------------------------------------------------------------------------------------------
	public void Subscribe(Action action, Value value)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == value);
		valueReference.onChange += action;
	}

	///-------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// A method call to handle attaching dependencies to a value(stat) and associating it with the proper recalculate method
	/// </summary>
	/// <param name="action">Method of recalculating</param>
	/// <param name="dependency">Value that is dependent on another</param>
	/// <param name="subscribeTo">Value that the depenency parameter will now have dependency on</param>
	///-------------------------------------------------------------------------------------------------------------
	public void Subscribe(Action<Value> action, Value dependency, Value subscribeTo)
	{
		ValueReference valueReference = stats.Find(item => item.valueBase == subscribeTo);
		if (valueReference.recalculate == null)
			valueReference.recalculate = action;

		if (valueReference.dependent == null)
			valueReference.dependent = new List<Value>();

		valueReference.dependent.Add(dependency);
	}
	#endregion Subscribe Methods
}
