using UnityEditor;
using UnityEngine;

namespace Modules.Actors.Editor
{
    [CustomPropertyDrawer(typeof(ActorComponents))]
    public class ActorComponentPropertyDrawer : PropertyDrawer
    {
        private const float _addButtonHeight = 20;
        private const float _arrayPropertyHeight = 20;

        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            var indent = EditorGUI.indentLevel;

            var behavioursArr = property.FindPropertyRelative("_exposedBehaviours");

            EditorGUI.BeginChangeCheck();
            
            for (var i = 0; i < behavioursArr.arraySize; i++)
            {
                var arrayProperty = behavioursArr.GetArrayElementAtIndex(i);

                DrawBehaviourArrayProperty(arrayProperty, behavioursArr, i, ref position);
            }
            
            position.y += _addButtonHeight;
            
            if (GUI.Button(GetAddBehaviourButtonRect(position), "Add Behaviour"))
            {
                behavioursArr.InsertArrayElementAtIndex(behavioursArr.arraySize);
                behavioursArr.GetArrayElementAtIndex(behavioursArr.arraySize - 1).objectReferenceValue = null;
            }

            if (EditorGUI.EndChangeCheck())
            {
                Debug.Log("AAA");
            }
            
            EditorGUI.indentLevel = indent;
            
        }

        private void DrawBehaviourArrayProperty(SerializedProperty property, SerializedProperty parent, int index,
            ref Rect position)
        {
            position.y += _arrayPropertyHeight;
            const float widthMultiplier = 4.0f / 5;

            var propertyName = property.objectReferenceValue == null
                ? $"{index + 1}"
                : property.objectReferenceValue.GetType().Name;
            
            EditorGUI.PropertyField(GetArrayPropertyRect(position, widthMultiplier), property,
                new GUIContent(propertyName));

            var xOffset = position.x + position.width * widthMultiplier;
            
            if (GUI.Button(GetRemoveBehaviourButtonRect(position, xOffset), "-"))
            {
                property.objectReferenceValue = null;
                parent.DeleteArrayElementAtIndex(index);
            }
        }

        private static Rect GetAddBehaviourButtonRect(Rect position)
        {
            return new Rect(position.x, position.y, position.width, _addButtonHeight);
        }

        private static Rect GetArrayPropertyRect(Rect position, float widthMultiplier)
        {
            return new Rect(position.x, position.y, position.width * widthMultiplier, _arrayPropertyHeight);
        }

        private static Rect GetRemoveBehaviourButtonRect(Rect position, float xOffset)
        {
            return new Rect(position.x + xOffset, position.y, position.width - xOffset, _arrayPropertyHeight);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var behavioursArr = property.FindPropertyRelative("_exposedBehaviours");
            return _addButtonHeight * 2 + _arrayPropertyHeight * behavioursArr.arraySize;
        }
    }
}