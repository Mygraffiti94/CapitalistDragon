using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///---------------------------------------------------------------------------------------------------------
/// <summary>
/// This class is the base object that will contain all the values we plan on using for Actor stats
/// </summary>
///---------------------------------------------------------------------------------------------------------
public class Value : ScriptableObject
{
	public string valueName;
	public Formula formula;
	public bool	isNull = true;
}
