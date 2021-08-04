using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base object that controls if an object is interactable or not
/// </summary>
public class Interactable : MonoBehaviour
{
	public Action<GameObject> onInteract;

	public void Interact(GameObject actor)
	{
		//Debug.Log("Interacted " + gameObject.name);
		onInteract?.Invoke(actor);

		if(onInteract == null)
		{
			Debug.LogWarning("No onINteract methods made for this Interactable");
		}
	}
}
