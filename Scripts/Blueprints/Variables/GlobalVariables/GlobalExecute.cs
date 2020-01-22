using Sirenix.OdinInspector;
using UnityEngine;

namespace BP
{
    [CreateAssetMenu(menuName = "MyAssets/Actions/GlobalExecute")]
    public class GlobalExecute : SerializedScriptableObject, IAction
    {
        public IAction action;

        public void Action()
        {
            action?.Action();
        }

        public class SimpleExecute : IExecute
        {
            public Delegates.IContainer GetContainer
            {
                get
                {
                    return methList;
                }
            }
            public Delegates.IContainer methList = new Delegates.ListContainer();

            public bool Invoke()
            {
                return methList.Invoke();
            }

            [Button]
            public virtual void Action()
            {
                if (this != null) Invoke();
            }
        }
    }
}
