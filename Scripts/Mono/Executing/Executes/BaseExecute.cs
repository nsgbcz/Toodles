using Toodles.Controllers;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Toodles.Iterates;

namespace Toodles.Executes
{
    public abstract class BaseExecute : SerializedMonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField, TextArea, PropertyOrder(1), FoldoutGroup("Description"), HideLabel]
        public string Description;

        [SerializeField, PropertyOrder(-11), HideLabel]
        internal FactoryData ExecuteType;
        [SerializeField,HideInInspector]
        internal FactoryData _executeType;

        /// <summary>
        /// It's needed, cause Odin doesn't support Neasted prefabs
        /// </summary>
        [ContextMenu("ReloadComponent")]
        public void ReloadComponent()
        {
            EditorUtility.CopySerialized(this, gameObject.AddComponent(GetType()));
            EditorUtility.SetDirty(gameObject);
            DestroyImmediate(this, true);
        }
        /*public void OnDrawGizmosSelected()
        {
            methList.OnDrawGizmosSelected();
        }*/
#endif
    }
}