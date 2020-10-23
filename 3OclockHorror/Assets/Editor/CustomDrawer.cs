using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustomDrawer : PropertyDrawer
{
    int rows = 7;
    int cols = 7;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
        Rect newPosition = position;
        newPosition.y += 18f;
        SerializedProperty data = property.FindPropertyRelative("data");
        //data.rows[0][]
        for (int j = 0; j < cols; j++)
        {
            SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
            newPosition.height = 18f;
            newPosition.width = newPosition.width / cols;
            for (int i = 0; i < rows; i++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(i));
                newPosition.x += newPosition.width;
            }

            newPosition.x = position.x;
            newPosition.y += 18f;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 8;
    }
}
