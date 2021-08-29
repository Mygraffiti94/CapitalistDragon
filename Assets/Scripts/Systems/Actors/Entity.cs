using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Scriptable object for an enemy. This will hold information of the enemy to be used to generate an enemy unit
/// </summary>
public class Entity : ScriptableObject
{
	public enum EntityType
	{
		None,
		Enemy,
		Character
	}

	public string entityName;
	public GameObject sprite;
	public ValueContainer stats;
	public ActorObject actorObject;
	public List<Ability> abilities;
	public EntityType entityType;

	private void OnEnable()
	{
		switch(entityType)
		{
			case EntityType.Enemy:
				if(stats == null)
				{
					stats = (ValueContainer)Embed(this, typeof(ValueContainer), "Stats");
					ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data Objects/Stats/StatStructures/EnemyStats.asset", typeof(ValueStructure));
					stats.Form(statsStructure);
				}
				break;
			case EntityType.Character:
				if(stats == null)
				{
					stats = (ValueContainer)Embed(this, typeof(ValueContainer), "Stats");
					ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data Objects/Stats/StatStructures/PlayerStats.asset", typeof(ValueStructure));
					stats.Form(statsStructure);
				}
				
				if(actorObject == null)
				{
					actorObject = (ActorObject)Embed(this, typeof(ActorObject), "ActorObject");
				}
				break;
			case EntityType.None:
				break;
		}
	}

	// Entity objects need stats to exist so we will create instances for them here
	static Entity CreateEntity(string path)
	{
		ValueStructure statsStructure;

		// Create the instance of enemy here
		Entity entity = CreateInstance<Entity>();
		AssetDatabase.CreateAsset(entity, AssetDatabase.GenerateUniqueAssetPath(path));
		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(entity));

		// Embed stats into the enemy asset
		entity.stats = (ValueContainer) Embed(entity, typeof(ValueContainer), "Stats");

		if(entity.entityType == EntityType.Enemy)
			statsStructure = (ValueStructure) AssetDatabase.LoadAssetAtPath("Assets/Data Objects/Stats/StatStructures/EnemyStats.asset", typeof(ValueStructure));
		else
			statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data Objects/Stats/StatStructures/PlayerStats.asset", typeof(ValueStructure));

		entity.stats.Form(statsStructure);

		return entity;
	}

	/// <summary>
	/// Method call to create the instance object of an enemy and preload it with everything needed to create the enemy with all its components done for us by Unity rather than us having to remember every piece of object that goes into an enemy
	/// </summary>
	[MenuItem("Assets/Create/Data/Enemy")]
	static void CreateEnemyInstance()
	{
		Entity entity = new Entity();
		entity.entityType = EntityType.Enemy;
		entity = CreateEntity(GetPath() + "/Enemy.asset");
	}

	/// <summary>
	/// Method call to create the instance object of an enemy and preload it with everything needed to create the enemy with all its components done for us by Unity rather than us having to remember every piece of object that goes into a character
	/// </summary>
	[MenuItem("Assets/Create/Data/Character")]
	static void CreateCharacterInstance()
	{
		Entity entity = new Entity();
		entity.entityType = EntityType.Character;
		entity = CreateEntity(GetPath() + "/Character.asset");

		entity.actorObject = (ActorObject) Embed(entity, typeof(ActorObject), "ActorObject");
	}

	private static ScriptableObject Embed(Entity entity, Type type, string name)
	{
		ScriptableObject scriptableObject = CreateInstance(type);
		AssetDatabase.AddObjectToAsset(scriptableObject, entity);
		scriptableObject.name = name;
		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(scriptableObject));
		return scriptableObject;
	}

	static string GetPath()
	{
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		// If we have no path selected, default it to the main Assets folder
		if (path == "")
		{
			path = "Assets";
		}
		else if (Path.GetExtension(path) != "")
		{
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}

		return path;
	}
}
