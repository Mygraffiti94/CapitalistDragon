using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Actor")]
public class ActorObject : ScriptableObject
{
	public string actorName;
	public int level;
	public Sprite characterPortrait;
	private Texture2D portraitTexture;
}
