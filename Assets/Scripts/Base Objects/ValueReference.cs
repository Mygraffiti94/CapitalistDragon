using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///---------------------------------------------------------------------------------------------------------
/// <summary>
/// This class is a midway class that organizes the various data types that we will need for our values
/// This allows us to have multiple data types that inherit from Value
/// </summary>
///---------------------------------------------------------------------------------------------------------
public class ValueReference 
{
	public Value valueBase;

}

public class ValueFloatReference : ValueReference
{
	public float value;

	public ValueFloatReference(Value _valueBase, float _value = 0)
	{
		valueBase = _valueBase;
		value = _value;
	}
}

public class ValueIntReference : ValueReference
{
	public int value;

	public ValueIntReference(Value _valueBase, int _value = 0)
	{
		valueBase = _valueBase;
		value = _value;
	}
}
