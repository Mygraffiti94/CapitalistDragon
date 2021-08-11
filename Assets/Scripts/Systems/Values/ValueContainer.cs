using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Value/Container")]
public class ValueContainer : ValueStructure
{
	public int[] integers;
	public float[] floats;

	internal void Form(ValueStructure statStructure)
	{
		if(values == null)
			values = new List<Value>();

		for(int i = 0; i < statStructure.values.Count; i++)
		{
			values.Add(statStructure.values[i]);
		}

		integers = new int[values.FindAll(x => x.GetType() == typeof(ValueInt)).Count];
		floats = new float[values.FindAll(x => x.GetType() == typeof(ValueFloat)).Count];
	}
}
