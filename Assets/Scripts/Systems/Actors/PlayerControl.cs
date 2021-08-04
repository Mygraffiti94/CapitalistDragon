using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float		moveSpeed;
	public GameObject	interactorBoxPivot;
	
	// Processing variables
	private Animator			moveAnimator;
	private	float				xInput;
	private float				yInput;
	private Transform			interactorTransform;
	private static Vector3		interactorRightVector;
	private static Vector3		interactorLeftVector;
	private static Vector3		interactorUpVector;
	private static Vector3		interactorDownVector;

    // Start is called before the first frame update
    void Start()
    {
        moveAnimator = GetComponent<Animator>();
		if(gameObject.transform.Find(interactorBoxPivot.name) != null)
			interactorTransform = gameObject.transform.Find(interactorBoxPivot.name).transform;

		interactorRightVector = new Vector3(0.5f, -0.25f);
		interactorLeftVector = new Vector3(-0.5f, -0.25f);
		interactorUpVector = new Vector3(0.0f, 0.5f);
		interactorDownVector = new Vector3(0.0f, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
		xInput = Input.GetAxisRaw("Horizontal");
		yInput = Input.GetAxisRaw("Vertical");

        if(xInput > 0f)
		{ 
			transform.Translate(new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, 0f));
			interactorTransform.position = new Vector3(interactorRightVector.x + transform.position.x, interactorRightVector.y + transform.position.y);
		}
		else if (Input.GetAxisRaw("Horizontal") < 0f)
		{ 
			transform.Translate(new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, 0f));
			interactorTransform.position = new Vector3(interactorLeftVector.x + transform.position.x, interactorLeftVector.y + transform.position.y);
		}
		if (Input.GetAxisRaw("Vertical") > 0f)
		{ 
			transform.Translate(new Vector3(0f, yInput * moveSpeed * Time.deltaTime, 0f));
			interactorTransform.position = new Vector3(interactorUpVector.x + transform.position.x, interactorUpVector.y + transform.position.y);
		}
		else if (Input.GetAxisRaw("Vertical") < 0f)
		{ 
			transform.Translate(new Vector3(0f, yInput * moveSpeed * Time.deltaTime, 0f));
			interactorTransform.position = new Vector3(interactorDownVector.x + transform.position.x, interactorDownVector.y + transform.position.y);
		}

		moveAnimator.SetFloat("MoveX", xInput);
		moveAnimator.SetFloat("MoveY", yInput);
		if(xInput > 0.1 || xInput < -0.1
		|| yInput > 0.1 || yInput < -0.1)
		{
			moveAnimator.SetFloat("LastMoveX", xInput);
			moveAnimator.SetFloat("LastMoveY", yInput);
		}
	}
}
