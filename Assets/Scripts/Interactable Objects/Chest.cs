using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] bool openedChest	= false;

	public void OpenChest()
	{
		if(openedChest == false)
		{
			transform.Rotate(0f, 0f, 90f);
		}
	}
}
