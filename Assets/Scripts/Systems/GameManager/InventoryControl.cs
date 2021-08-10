﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
	private void Update()
	{
		if(Input.GetKeyUp(KeyCode.I))
		{
			GameManager.instance.guiManager.OpenInventory(false);
			GameManager.instance.SetControlScheme(ControlScheme.Exploration);
		}	
	}
}
