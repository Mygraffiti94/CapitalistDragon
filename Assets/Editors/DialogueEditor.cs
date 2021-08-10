using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Dialogue))]
public class DialogueEditor : Editor
{
	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		Show();

		serializedObject.ApplyModifiedProperties();
	}

	private void Show()
	{
		int actorIndex = 0;
		SerializedProperty textList = serializedObject.FindProperty("text");
		SerializedProperty actorList = serializedObject.FindProperty("actor");
		EditorGUILayout.PropertyField(textList.FindPropertyRelative("Array.size"));
		actorList.arraySize = textList.arraySize;

		for (int textIndex = 0; textIndex < textList.arraySize; textIndex++)
		{
			// Begin a new horizontal line to display the actor next to the speaking line
			EditorGUILayout.BeginHorizontal();

			// Grab the properties of the actors and the text
			SerializedProperty actorProperty = actorList.GetArrayElementAtIndex(textIndex);
			SerializedProperty textProperty = textList.GetArrayElementAtIndex(textIndex);

			// Display the properties
			EditorGUILayout.PropertyField(actorProperty, GUIContent.none);
			EditorGUILayout.PropertyField(textProperty, GUIContent.none);

			// End the horizontal
			EditorGUILayout.EndHorizontal();
		}
	}
}
