using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using UnityEditorInternal;
using UnityEngine.AI;
using UnityEditor.AI;
using UnityEditor;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;

namespace Toodles.Editor
{
    public class NavAreaMaskAttributeDrawer : OdinAttributeDrawer<NavAreaMaskAttribute, int>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var rect = EditorGUILayout.GetControlRect();

            var areaMask = this.ValueEntry.SmartValue;

            var areaNames = GameObjectUtility.GetNavMeshAreaNames();

            ValueEntry.SmartValue = EditorGUI.MaskField(rect, label, areaMask, areaNames);
        }
    }
}