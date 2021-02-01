using Editor;
using Modules.Behaviours;
using UnityEditor;
using UnityEngine;

namespace Modules.Actors.Editor
{
    [CustomPropertyDrawer(typeof(ActorComponents))]
    public class ActorComponentPropertyDrawer : PropertyDrawer
    {
        private const float _addButtonHeight = 20;
        private const float _arrayPropertyHeight = 20;

        private SerializedProperty _cachedArray;
        
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
            DropAreGui(ref position, behavioursArr, property);

            EditorGUI.indentLevel = indent;
        }

        private void DropAreGui(ref Rect position, SerializedProperty behavioursArr, SerializedProperty property)
        {
            var ev = Event.current;
            var dropRect = position.GetCopy(_arrayPropertyHeight);
            
            GUI.Box(dropRect, "Add behaviour");

            switch (ev.type)
            {
                case EventType.DragUpdated:
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                    Event.current.Use();
                    break;
                }
                case EventType.DragPerform:
                {
                    if (!dropRect.Contains(ev.mousePosition))
                    {
                        return;
                    }

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                    
                    if (ev.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag ();
             
                        foreach (var draggedObject in DragAndDrop.objectReferences) 
                        {
                            if (draggedObject is IBaseBehaviour)
                            {
                                if (Application.isPlaying)
                                {
                                    var target = property.serializedObject.targetObject as Actor;
                                    target?.AddBehaviour(draggedObject as BaseBehaviour);
                                }
                                else
                                {
                                    behavioursArr.InsertArrayElementAtIndex(behavioursArr.arraySize);
                                    behavioursArr.GetArrayElementAtIndex(behavioursArr.arraySize - 1).objectReferenceValue
                                        = draggedObject;
                                }
                            }
                            
                            EditorUtility.SetDirty(Selection.activeObject);
                        }
                    }
                    break;
                }
            }
        }

        private void DrawBehaviourArrayProperty(SerializedProperty property, SerializedProperty parent, int index,
            ref Rect position)
        {
            position.y += _arrayPropertyHeight;
            const float widthMultiplier = 4.0f / 5;

            var propertyName = property.objectReferenceValue == null
                ? $"{index + 1}"
                : property.objectReferenceValue.GetType().Name;

            GUI.enabled = false;
            var arrayPropertyRect = position.GetCopy(_arrayPropertyHeight, widthMultiplier);
            EditorGUI.PropertyField(arrayPropertyRect, property, new GUIContent(propertyName));
            GUI.enabled = true;
            
            var offset = position.x + position.width * widthMultiplier;
            var removeButtonHeight = position.GetCopy(_arrayPropertyHeight, xOffset: offset);
            
            if (GUI.Button(removeButtonHeight, "-"))
            {
                if (Application.isPlaying)
                {
                    var target = property.serializedObject.targetObject as Actor;
                    var removedObject = property.objectReferenceValue as BaseBehaviour;
                    target.RemoveBehaviour(removedObject.GetType());
                }
                else
                {
                    property.objectReferenceValue = null;
                    parent.DeleteArrayElementAtIndex(index);
                }
                
                EditorUtility.SetDirty(Selection.activeObject);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var behavioursArr = property.FindPropertyRelative("_exposedBehaviours");
            return _addButtonHeight * 2 + _arrayPropertyHeight * behavioursArr.arraySize;
        }
    }
}