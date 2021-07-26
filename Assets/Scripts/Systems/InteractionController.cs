﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object that will trigger objects with Interactable components
/// </summary>
public class InteractionController : MonoBehaviour
{
	[SerializeField] Transform boxPivot;
	[SerializeField] Vector2 boxHalfSize = Vector2.one;

	private float	chestWaitTime;

	// Update is called once per frame
	void Update()
	{
		// TODO: Replace with proper input key
		if (Input.GetKeyDown(KeyCode.Z))
		{
			CheckInteract();
		}
	}

	/// <summary>
	/// Method call that compares if the boxPivot object (basically the interaction zone of player) is overlapping
	/// an object that contains an interacatable property. If multiple does, we call whichever comes up first
	/// </summary>
	private void CheckInteract()
	{
		Collider2D[] colliders = Physics2D.OverlapBoxAll(boxPivot.position, boxHalfSize, 0);
		foreach (var collider in colliders)
		{
			Interactable interactable = collider.GetComponent<Interactable>();
			if (interactable != null)
			{
				interactable.Interact(gameObject);
				break;
			}
		}
	}
}
