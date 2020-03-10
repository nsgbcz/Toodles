using Toodles.Controllers;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Toodles.Delegates;

namespace Toodles.Executers
{
    public class Execute : SerializedMonoBehaviour, IExecute
    {
#if UNITY_EDITOR
        [SerializeField, TextArea, PropertyOrder(1), FoldoutGroup("Description"), HideLabel]
        public string Description;

        [SerializeField]
        internal ExecuteFactory.ExecuteType  type = ExecuteFactory.ExecuteType.Nothing;

        [SerializeField, HideInInspector]
        internal ExecuteFactory.ExecuteType _type = ExecuteFactory.ExecuteType.Nothing;
        protected void OnValidate()
        {
            if (_type == type) return;
            new ExecuteFactory(this).Produce();
        }

        bool ShowActionButton { get => iterate != null; }
        bool ShowBuildButton { get => iterate is IBuilder; }
        [Button, ShowIf("ShowBuildButton"), PropertyOrder(2)]
        public virtual void Build()
        {
            var builder = iterate as IBuilder;
            iterate = builder?.GetAct();
        }
#endif
        [PropertyOrder(-10)]
        public IIteratable iterate = new ListIterable();

        [Button, ShowIf("ShowActionButton"), PropertyOrder(3)]
        public virtual void Action()
        {
            if (this != null && Iterate()) Destroy(this);
        }
        public bool Iterate()
        {
            return iterate.Iterate();
        }

#if UNITY_EDITOR
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