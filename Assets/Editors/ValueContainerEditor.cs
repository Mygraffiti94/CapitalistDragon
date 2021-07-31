using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(ValueContainer))]
public class ValueContainerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		Show(serializedObject.FindProperty("values"));

		// Actually applies the changes
		serializedObject.ApplyModifiedProperties();
	}

	int integerIndex = 0;
	int floatIndex = 0;

	private void Show(SerializedProperty list)
	{
		integerIndex = 0;
		floatIndex = 0;

		EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));

		for(int i = 0; i < list.arraySize; i++)
		{
			EditorGUILayout.BeginHorizontal();
			SerializedProperty serializedProperty = list.GetArrayElementAtIndex(i);
			EditorGUILayout.PropertyField(serializedProperty, GUIContent.none);
			ShowState(serializedProperty);
			EditorGUILayout.EndHorizontal();
		}
	}

	private void ShowState(SerializedProperty serializedProperty)
	{
		if(serializedProperty.objectReferenceValue == null) {  return; }
		if(serializedProperty.objectReferenceValue.GetType() == typeof(ValueInt))
		{
			ShowValueField("integers", integerIndex);
			integerIndex++;
		}
		else if(serializedProperty.objectReferenceValue.GetType() == typeof(ValueFloat))
		{
			ShowValueField("floats", floatIndex);
			floatIndex++;
		}
	}

	private void ShowValueField(string valueArray, int index)
	{
		SerializedProperty list = serializedObject.FindProperty(valueArray);
		if(index >= list.arraySize)
		{
			list.arraySize += 1;
		}

		SerializedProperty arrayElement = list.GetArrayElementAtIndex(index);
		if(arrayElement != null)
		{
			EditorGUILayout.PropertyField(arrayElement, GUIContent.none);
		}
	}
}
