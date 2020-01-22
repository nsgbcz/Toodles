using BP.Delegates;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace BP
{
    public class Execute : SerializedMonoBehaviour, IExecute
    {

        /*#if UNITY_EDITOR
            public string Description;
        #endif*/
        public IContainer GetContainer
        {
            get
            {
                return methList;
            }
        }
        public IContainer methList = new ListContainer();

        public bool Invoke()
        {
            return methList.Invoke();
        }

        [Button]
        public virtual void Action()
        {
            if (this != null && Invoke()) Destroy(this);
        }

        public void AddInvoke(IInvoke<bool> invoke)
        {
            methList.Add(invoke);
        }
        public void AddAction(IAction act, bool oneInvocation = true)
        {
            methList.Add(new Act(act, oneInvocation));
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