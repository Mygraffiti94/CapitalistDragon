using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public Action onInteract;

	public void Interact()
	{
		Debug.Log("Interacted " + gameObject.name);
		onInteract?.Invoke();

		if(onInteract == null)
		{
			Debug.LogWarning("No onINteract methods made for this Interactable");
		}
	}
}
