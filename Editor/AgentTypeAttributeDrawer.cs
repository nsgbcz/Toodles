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
    public class AgentTypeAttributeDrawer : OdinAttributeDrawer<AgentTypeAttribute, int>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var rect = EditorGUILayout.GetControlRect();
            if (label != null)
                rect = EditorGUI.PrefixLabel(rect, label);

            var agentType = this.ValueEntry.SmartValue;

            var count = NavMesh.GetSettingsCount();
            var agentTypeNames = new string[count];
            for (var i = 0; i < count; i++)
            {
                var id = NavMesh.GetSettingsByIndex(i).agentTypeID;
                var name = NavMesh.GetSettingsNameFromID(id);
                agentTypeNames[i] = name;
            }

            ValueEntry.SmartValue = EditorGUI.Popup(rect, agentType, agentTypeNames);
        }
    }
}