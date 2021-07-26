using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransition : MonoBehaviour
{
	public string sceneToTransition;

	/// <summary>
	/// Method call to load next scene
	/// </summary>
	/// <param name="collision">Collider</param>
	private void OnTriggerEnter2D(Collider2D collision)
	{
		SceneManager.LoadScene(sceneToTransition);
	}
}
