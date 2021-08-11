using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Scriptable object for an enemy. Will generate a full asset based off the object as enemies require to be fully instantiated to exist.
/// Enemy will instantiate and create an asset for all its components when created inside the editor. This way the Enemy will always have every
/// object it needs to exist but all the while have everything contained in one place so that when modifiying/deleting, it becomes very painless
/// </summary>
public class Enemy : ScriptableObject
{
	public string enemyName;
	public GameObject sprite;
	public ValueContainer stats;

	// Enemy objects need stats to exist so we will create instances for them here
	[MenuItem("Assets/Create/Data/Enemy")]
	static void CreateInstance()
	{
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		// If we have no path selected, default it to the main Assets folder
		if(path == "")
		{
			path = "Assets";
		}
		else if (Path.GetExtension(path) != "")
		{
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}

		// Create the instance of enemy here
		Enemy enemy = CreateInstance<Enemy>();
		AssetDatabase.CreateAsset(enemy, AssetDatabase.GenerateUniqueAssetPath(path + "/Enemy.asset"));
		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(enemy));

		// Embed stats into the enemy asset
		enemy.stats = CreateInstance<ValueContainer>();
		AssetDatabase.AddObjectToAsset(enemy.stats, enemy);
		enemy.stats.name = "Enemy Stats";
		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(enemy.stats));

		ValueStructure statsStructure = (ValueStructure) AssetDatabase.LoadAssetAtPath("Assets/Data Objects/Stats/StatStructures/EnemyStats.asset", typeof(ValueStructure));
		enemy.stats.Form(statsStructure);
	}
}
