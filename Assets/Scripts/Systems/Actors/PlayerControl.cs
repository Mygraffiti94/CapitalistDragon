using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that controls movement of player
/// </summary>
public class PlayerControl : MonoBehaviour
{
	public float		moveSpeed = 5.0f;
	public GameObject	interactorBoxPivot;
	public GameObject			character;
	public LayerMask	groundLayer;

	// Processing variables
	private Animator			moveAnimator;
	private	float				xInput;
	private float				yInput;
	private Transform			characterTransform;
	private Transform			interactorTransform;
	private static Vector3		interactorRightVector;
	private static Vector3		interactorLeftVector;
	private static Vector3		interactorUpVector;
	private static Vector3		interactorDownVector;
	private InteractionController interactionController;
	private int	encounterCD = 15;


	public void Init(GameObject newTarget)
	{
		character = newTarget;
		moveAnimator = character.GetComponent<Animator>();

		if (character.transform.Find(interactorBoxPivot.name) != null)
			interactorTransform = character.transform.Find(interactorBoxPivot.name).transform;
		
		characterTransform = character.transform;

		interactorRightVector = new Vector3(0.5f, -0.25f);
		interactorLeftVector = new Vector3(-0.5f, -0.25f);
		interactorUpVector = new Vector3(0.0f, 0.5f);
		interactorDownVector = new Vector3(0.0f, -1.0f);

		interactionController = character.GetComponent<InteractionController>();
	}

    void Update()
    {
		// Get input from the direction player wants
		xInput = Input.GetAxisRaw("Horizontal");
		yInput = Input.GetAxisRaw("Vertical");

		if(character == null) { return; }

		//Check for right movement
        if(xInput > 0f)
		{
			characterTransform.Translate(new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, 0f));
			interactorTransform.position = new Vector3(interactorRightVector.x + characterTransform.position.x, interactorRightVector.y + characterTransform.position.y);
		}
		// Check for left movement
		else if (Input.GetAxisRaw("Horizontal") < 0f)
		{
			characterTransform.Translate(new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, 0f));
			interactorTransform.position = new Vector3(interactorLeftVector.x + characterTransform.position.x, interactorLeftVector.y + characterTransform.position.y);
		}
		// Check for up movement
		if (Input.GetAxisRaw("Vertical") > 0f)
		{
			characterTransform.Translate(new Vector3(0f, yInput * moveSpeed * Time.deltaTime, 0f));
			interactorTransform.position = new Vector3(interactorUpVector.x + characterTransform.position.x, interactorUpVector.y + characterTransform.position.y);
		}
		//Check for down movement
		else if (Input.GetAxisRaw("Vertical") < 0f)
		{
			characterTransform.Translate(new Vector3(0f, yInput * moveSpeed * Time.deltaTime, 0f));
			interactorTransform.position = new Vector3(interactorDownVector.x + characterTransform.position.x, interactorDownVector.y + characterTransform.position.y);
		}

		// Set variables for the animator so we have proper movement animations
		moveAnimator.SetFloat("MoveX", xInput);
		moveAnimator.SetFloat("MoveY", yInput);
		if(xInput > 0.1 || xInput < -0.1
		|| yInput > 0.1 || yInput < -0.1)
		{
			moveAnimator.SetFloat("LastMoveX", xInput);
			moveAnimator.SetFloat("LastMoveY", yInput);

			// Check for encounters
			if(GameManager.instance.encounterManager.hasEncounters == true)
			{ 
				if(UnityEngine.Random.Range(0, 1000) < 100)
				{ 
					if(encounterCD < 1)
					{ 
						GameManager.instance.encounterManager.StartEncounter();
						encounterCD = 11;
					}
					encounterCD--;
				}
			}
		}

		// Check for interaction
		if(Input.GetKeyUp(KeyCode.Z))
		{
			interactionController.CheckInteract();
		}

		// Check for inventory press
		if(Input.GetKeyUp(KeyCode.I))
		{
			GameManager.instance.guiManager.OpenInventory(true);
			GameManager.instance.SetControlScheme(ControlScheme.Inventory);
		}
	}
}
