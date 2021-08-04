using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDebugMessage : InteractableModule
{
	public override void Interact(GameObject actor)
	{
		Debug.Log("This is a debug message");
	}
}
