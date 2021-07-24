using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
	[SerializeField] Transform boxPivot;
	[SerializeField] Vector2 boxHalfSize = Vector2.one;

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			CheckInteract();
		}
    }

	private void CheckInteract()
	{
		Collider2D[] colliders = Physics2D.OverlapBoxAll(boxPivot.position, boxHalfSize, 0);
		foreach(var collider in colliders)
		{
			Interactable interactable = collider.GetComponent<Interactable>();
			if(interactable != null)
			{
				interactable.Interact();
				break;
			}
		}
	}
}
