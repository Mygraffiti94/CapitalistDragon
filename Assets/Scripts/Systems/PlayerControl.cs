using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float moveSpeed;
	
	// Processing variables
	private Animator	moveAnimator;
	private	float		xInput;
	private float		yInput;

    // Start is called before the first frame update
    void Start()
    {
        moveAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		xInput = Input.GetAxisRaw("Horizontal");
		yInput = Input.GetAxisRaw("Vertical");

        if(xInput > 0f)
			transform.Translate(new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, 0f));
		else if (Input.GetAxisRaw("Horizontal") < 0f)
			transform.Translate(new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, 0f));
		if (Input.GetAxisRaw("Vertical") > 0f)
			transform.Translate(new Vector3(0f, yInput * moveSpeed * Time.deltaTime, 0f));
		else if (Input.GetAxisRaw("Vertical") < 0f)
			transform.Translate(new Vector3(0f, yInput * moveSpeed * Time.deltaTime, 0f));

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
