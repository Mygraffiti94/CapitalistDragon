using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///---------------------------------------------------------------------------------------------------------
/// <summary>
/// This class is a midway class that organizes the various data types that we will need for our values
/// This allows us to have multiple data types that inherit from Value
/// </summary>
///---------------------------------------------------------------------------------------------------------
public abstract class ValueReference 
{
	//--------------------------
	// Declarations
	//--------------------------
	public Value			valueBase;

	public Action			onChange;
	public Action<Value>	recalculate;

	public List<Value>		dependent;

	public virtual string	TEXT { get; internal set;}

	public abstract void	Null();

	internal void RecalculateDepdencies()
	{
		if(dependent != null)
		{
			foreach(Value value in dependent)
			{
				recalculate?.Invoke(value);
			}
		}
	}
}
///---------------------------------------------------------------------------------------------------------
/// <summary>
/// Class that will hold reference to a float
/// </summary>
///---------------------------------------------------------------------------------------------------------
public class ValueFloatReference : ValueReference
{
	public float value;

	///----------------------------------------------------
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="_valueBase">BaseValue object</param>
	/// <param name="_value">Initialization value</param>
	///----------------------------------------------------
	public ValueFloatReference(Value _valueBase, float _value = 0)
	{
		valueBase = _valueBase;
		value = _value;
	}

	///----------------------------------------------------
	/// <summary>
	/// Adds the given number to the stats
	/// </summary>
	/// <param name="sum">Number to add</param>
	///----------------------------------------------------
	internal void Add(float sum)
	{
		value += sum;
		onChange?.Invoke();
		RecalculateDepdencies();
	}

	internal void SetValue(float sum)
	{
		value = sum;
		onChange?.Invoke();
		RecalculateDepdencies();
	}

	public override void Null()
	{
		value = 0f;
		onChange?.Invoke();
		RecalculateDepdencies();
	}

	///----------------------------------------------------
	/// <summary>
	/// Override of method to return a string form of the value
	/// </summary>
	///----------------------------------------------------
	public override string TEXT
	{
		get
		{
			return valueBase.name + ": " + value.ToString();
		}
	}
}

///---------------------------------------------------------------------------------------------------------
/// <summary>
/// Class that will hold a reference to an int
/// </summary>
///---------------------------------------------------------------------------------------------------------
public class ValueIntReference : ValueReference
{
	public int value;

	///----------------------------------------------------
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="_valueBase">BaseValue object</param>
	/// <param name="_value">Initialization value</param>
	///----------------------------------------------------
	public ValueIntReference(Value _valueBase, int _value = 0)
	{
		valueBase = _valueBase;
		value = _value;
		valueBase.isNull = true;
	}

	///----------------------------------------------------
	/// <summary>
	/// Adds the given number to the stats
	/// </summary>
	/// <param name="val">Number to add</param>
	///----------------------------------------------------
	internal void Add(int val)
	{
		value += val;
		valueBase.isNull = false;
		onChange?.Invoke();
		RecalculateDepdencies();
	}

	///----------------------------------------------------
	/// <summary>
	/// Sets the given sum to the Value 
	/// </summary>
	/// <param name="val"></param>
	///----------------------------------------------------
	internal void SetValue(int val)
	{
		value = val;
		valueBase.isNull = false;
		onChange?.Invoke();
		RecalculateDepdencies();
	}

	///----------------------------------------------------
	/// <summary>
	/// Set the value to "null"
	/// </summary>
	///----------------------------------------------------
	public override void Null()
	{
		value = 0;
		valueBase.isNull = true;
		onChange?.Invoke();
		RecalculateDepdencies();
	}

	///----------------------------------------------------
	/// <summary>
	/// Override of method to return a string form of the value
	/// </summary>
	///----------------------------------------------------
	public override string TEXT
	{
		get
		{
			return valueBase.name + ": " + value.ToString();
		}
	}
}
