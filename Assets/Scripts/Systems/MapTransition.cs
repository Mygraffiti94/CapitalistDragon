using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransition : MonoBehaviour
{
	public string sceneToTransition;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		SceneManager.LoadScene(sceneToTransition);
	}
}
