using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that will control the canvas settings for dialogue
/// </summary>
public class DialogueControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyUp(KeyCode.Z))
		{
			GameManager.instance.dialogueManager.Next();
		}
    }
}
