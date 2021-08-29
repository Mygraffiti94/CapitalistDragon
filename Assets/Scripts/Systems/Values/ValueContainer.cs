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
		copyOf = statStructure;

		integers = new int[copyOf.values.FindAll(x => x.GetType() == typeof(ValueInt)).Count];
		floats = new float[copyOf.values.FindAll(x => x.GetType() == typeof(ValueFloat)).Count];
	}

	internal void Copy(ref StatsContainer statList)
	{
		int intIndex = 0;
		int floatIndex = 0;

		List<Value> values;
		if(copyOf != null)
			values = copyOf.values;
		else
			values = this.values;

		for(int i = 0; i < values.Count; i++)
		{
			if(values[i] is ValueFloat)
			{
				statList.stats.Add(new ValueFloatReference(values[i], floats[floatIndex]));
				floatIndex++;
			}
			else if(values[i] is ValueInt)
			{
				statList.stats.Add(new ValueIntReference(values[i], integers[intIndex]));
				intIndex++;
			}
		}
	}
}
